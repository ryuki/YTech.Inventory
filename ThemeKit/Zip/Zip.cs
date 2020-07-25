// Zip.cs
//
// This class reads and writes zip files, according to the format
// described by pkware, at:
// http://www.pkware.com/business_and_developers/developer/popups/appnote.txt
//
// This implementation is based on the
// System.IO.Compression.DeflateStream base class in the .NET Framework
// v2.0 base class library.
//
// There are other Zip class libraries available.  For example, it is
// possible to read and write zip files within .NET via the J# runtime.
// But some people don't like to install the extra DLL.  Also, there is
// a 3rd party LGPL-based (or is it GPL?) library called SharpZipLib,
// which works, in both .NET 1.1 and .NET 2.0.  But some people don't
// like the GPL. Finally, there are commercial tools (From ComponentOne,
// XCeed, etc).  But some people don't want to incur the cost.
//
// This alternative implementation is not GPL licensed, is free of cost,
// and does not require J#.
//
// It does require .NET 2.0 (for the DeflateStream class).  
//
// Notes:
// This is at best a cripppled and naive implementation. 
//
// Bugs:
// 1. does not do 0..9 compression levels (not supported by DeflateStream)
// 2. does not do encryption
// 3. no support for reading or writing multi-disk zip archives
// 4. no support for file comments or archive comments
// 5. does not stream as it compresses; all compressed data is kept in memory.
// 6. no support for double-byte chars in filenames
// 7. no support for asynchronous operation
// 
// But it does read and write basic zip files, and it gets reasonable compression. 
//
// NB: PKWare's zip specification states: 
//
// ----------------------
//   PKWARE is committed to the interoperability and advancement of the
//   .ZIP format.  PKWARE offers a free license for certain technological
//   aspects described above under certain restrictions and conditions.
//   However, the use or implementation in a product of certain technological
//   aspects set forth in the current APPNOTE, including those with regard to
//   strong encryption or patching, requires a license from PKWARE.  Please 
//   contact PKWARE with regard to acquiring a license.
// ----------------------
//    
// Fri, 31 Mar 2006  14:43
//

using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace ionic.utils.zip
{
  class Utils
  {
    protected internal static string StringFromBuffer(byte[] buf, int start, int maxlength)
    {
      int i;
      char[] c = new char[maxlength];
      for (i = 0; (i < maxlength) && (i < buf.Length) && (buf[i] != 0); i++)
      {
        c[i] = (char)buf[i]; // System.BitConverter.ToChar(buf, start+i*2);
      }
      string s = new System.String(c, 0, i);
      return s;
    }

    protected internal static int ReadSignature(System.IO.Stream s)
    {
      int n = 0;
      byte[] sig = new byte[4];
      n = s.Read(sig, 0, sig.Length);
      int signature = (((sig[3] * 256 + sig[2]) * 256) + sig[1]) * 256 + sig[0];
      return signature;
    }

    protected internal static DateTime PackedToDateTime(Int32 packedDateTime)
    {
      Int16 packedTime = (Int16)(packedDateTime & 0x0000ffff);
      Int16 packedDate = (Int16)((packedDateTime & 0xffff0000) >> 16);

      int year = 1980 + ((packedDate & 0xFE00) >> 9);
      int month = (packedDate & 0x01E0) >> 5;
      int day = packedDate & 0x001F;


      int hour = (packedTime & 0xF800) >> 11;
      int minute = (packedTime & 0x07E0) >> 5;
      int second = packedTime & 0x001F;

      DateTime d = System.DateTime.Now;
      try { d = new System.DateTime(year, month, day, hour, minute, second, 0); }
      catch
      {
        Console.Write("\nInvalid date/time?:\nyear: {0} ", year);
        Console.Write("month: {0} ", month);
        Console.WriteLine("day: {0} ", day);
        Console.WriteLine("HH:MM:SS= {0}:{1}:{2}", hour, minute, second);
      }

      return d;
    }


    protected internal static Int32 DateTimeToPacked(DateTime time)
    {
      UInt16 packedDate = (UInt16)((time.Day & 0x0000001F) | ((time.Month << 5) & 0x000001E0) | (((time.Year - 1980) << 9) & 0x0000FE00));
      UInt16 packedTime = (UInt16)((time.Second & 0x0000001F) | ((time.Minute << 5) & 0x000007E0) | ((time.Hour << 11) & 0x0000F800));
      return (Int32)(((UInt32)(packedDate << 16)) | packedTime);
    }
  }





  public class ZipDirEntry
  {

    internal const int ZipDirEntrySignature = 0x02014b50;

    private bool _Debug = false;

    private ZipDirEntry() { }

    private DateTime _LastModified;
    public DateTime LastModified
    {
      get { return _LastModified; }
    }

    private string _FileName;
    public string FileName
    {
      get { return _FileName; }
    }

    private string _Comment;
    public string Comment
    {
      get { return _Comment; }
    }

    private Int16 _VersionMadeBy;
    public Int16 VersionMadeBy
    {
      get { return _VersionMadeBy; }
    }

    private Int16 _VersionNeeded;
    public Int16 VersionNeeded
    {
      get { return _VersionNeeded; }
    }

    private Int16 _CompressionMethod;
    public Int16 CompressionMethod
    {
      get { return _CompressionMethod; }
    }

    private Int32 _CompressedSize;
    public Int32 CompressedSize
    {
      get { return _CompressedSize; }
    }

    private Int32 _UncompressedSize;
    public Int32 UncompressedSize
    {
      get { return _UncompressedSize; }
    }


    private Int16 _BitField;
    private Int32 _LastModDateTime;

    private Int32 _Crc32;
    private byte[] _Extra;

    internal ZipDirEntry(ZipEntry ze) { }


    public static ZipDirEntry Read(System.IO.Stream s)
    {
      return Read(s, false);
    }


    public static ZipDirEntry Read(System.IO.Stream s, bool TurnOnDebug)
    {
      int signature = Utils.ReadSignature(s);
      // return null if this is not a local file header signature
      if (SignatureIsNotValid(signature))
      {
        s.Seek(-4, System.IO.SeekOrigin.Current);
        return null;
      }

      byte[] block = new byte[42];
      int n = s.Read(block, 0, block.Length);
      if (n != block.Length) return null;

      int i = 0;
      ZipDirEntry zde = new ZipDirEntry();

      zde._Debug = TurnOnDebug;
      zde._VersionMadeBy = (short)(block[i++] + block[i++] * 256);
      zde._VersionNeeded = (short)(block[i++] + block[i++] * 256);
      zde._BitField = (short)(block[i++] + block[i++] * 256);
      zde._CompressionMethod = (short)(block[i++] + block[i++] * 256);
      zde._LastModDateTime = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;
      zde._Crc32 = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;
      zde._CompressedSize = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;
      zde._UncompressedSize = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;

      zde._LastModified = Utils.PackedToDateTime(zde._LastModDateTime);

      Int16 filenameLength = (short)(block[i++] + block[i++] * 256);
      Int16 extraFieldLength = (short)(block[i++] + block[i++] * 256);
      Int16 commentLength = (short)(block[i++] + block[i++] * 256);
      Int16 diskNumber = (short)(block[i++] + block[i++] * 256);
      Int16 internalFileAttrs = (short)(block[i++] + block[i++] * 256);
      Int32 externalFileAttrs = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;
      Int32 Offset = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;

      block = new byte[filenameLength];
      n = s.Read(block, 0, block.Length);
      zde._FileName = Utils.StringFromBuffer(block, 0, block.Length);

      zde._Extra = new byte[extraFieldLength];
      n = s.Read(zde._Extra, 0, zde._Extra.Length);

      block = new byte[commentLength];
      n = s.Read(block, 0, block.Length);
      zde._Comment = Utils.StringFromBuffer(block, 0, block.Length);

      return zde;
    }

    private static bool SignatureIsNotValid(int signature)
    {
      return (signature != ZipDirEntrySignature);
    }

  }

  public class ZipEntry
  {
    private const int ZipEntrySignature = 0x04034b50;

    private DateTime _LastModified;
    public DateTime LastModified
    {
      get { return _LastModified; }
    }

    private string _FileName;
    public string FileName
    {
      get { return _FileName; }
    }

    private Int16 _VersionNeeded;
    public Int16 VersionNeeded
    {
      get { return _VersionNeeded; }
    }

    private Int16 _BitField;
    public Int16 BitField
    {
      get { return _BitField; }
    }

    private Int16 _CompressionMethod;
    public Int16 CompressionMethod
    {
      get { return _CompressionMethod; }
    }

    private Int32 _CompressedSize;
    public Int32 CompressedSize
    {
      get { return _CompressedSize; }
    }

    private Int32 _UncompressedSize;
    public Int32 UncompressedSize
    {
      get { return _UncompressedSize; }
    }

    private Int32 _LastModDateTime;
    private Int32 _Crc32;
    private byte[] _Extra;

    private byte[] __filedata;
    private byte[] _FileData
    {
      get
      {
        if (__filedata == null)
        {
        }
        return __filedata;
      }
    }

    private System.IO.MemoryStream _UnderlyingMemoryStream;
    private System.IO.Compression.DeflateStream _CompressedStream;
    private System.IO.Compression.DeflateStream CompressedStream
    {
      get
      {
        if (_CompressedStream == null)
        {
          _UnderlyingMemoryStream = new System.IO.MemoryStream();
          bool LeaveUnderlyingStreamOpen = true;
          _CompressedStream = new System.IO.Compression.DeflateStream(_UnderlyingMemoryStream,
                            System.IO.Compression.CompressionMode.Compress,
                            LeaveUnderlyingStreamOpen);
        }
        return _CompressedStream;
      }
    }

    private byte[] _header;
    internal byte[] Header
    {
      get
      {
        return _header;
      }
    }

    private int _RelativeOffsetOfHeader;


    private static bool ReadHeader(System.IO.Stream s, ZipEntry ze)
    {
      int signature = Utils.ReadSignature(s);

      // return null if this is not a local file header signature
      if (SignatureIsNotValid(signature))
      {
        s.Seek(-4, System.IO.SeekOrigin.Current);
        return false;
      }

      byte[] block = new byte[26];
      int n = s.Read(block, 0, block.Length);
      if (n != block.Length) return false;

      int i = 0;
      ze._VersionNeeded = (short)(block[i++] + block[i++] * 256);
      ze._BitField = (short)(block[i++] + block[i++] * 256);
      ze._CompressionMethod = (short)(block[i++] + block[i++] * 256);
      ze._LastModDateTime = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;
      ze._Crc32 = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;
      ze._CompressedSize = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;
      ze._UncompressedSize = block[i++] + block[i++] * 256 + block[i++] * 256 * 256 + block[i++] * 256 * 256 * 256;

      Int16 filenameLength = (short)(block[i++] + block[i++] * 256);
      Int16 extraFieldLength = (short)(block[i++] + block[i++] * 256);

      ze._LastModified = Utils.PackedToDateTime(ze._LastModDateTime);

      block = new byte[filenameLength];
      n = s.Read(block, 0, block.Length);
      ze._FileName = Utils.StringFromBuffer(block, 0, block.Length);

      ze._Extra = new byte[extraFieldLength];
      n = s.Read(ze._Extra, 0, ze._Extra.Length);

      return true;
    }


    private static bool SignatureIsNotValid(int signature)
    {
      return (signature != ZipEntrySignature);
    }

    public static ZipEntry Read(System.IO.Stream s)
    {
      ZipEntry entry = new ZipEntry();
      if (!ReadHeader(s, entry)) return null;

      entry.__filedata = new byte[entry.CompressedSize];
      int n = s.Read(entry._FileData, 0, entry._FileData.Length);
      if (n != entry._FileData.Length)
      {
        throw new Exception("badly formatted zip file.");
      }

      return entry;
    }

    internal static ZipEntry Create(String filename)
    {
      ZipEntry entry = new ZipEntry();
      entry._FileName = filename;

      entry._LastModified = System.IO.File.GetLastWriteTime(filename);
      if (entry._LastModified.IsDaylightSavingTime())
      {
        System.DateTime AdjustedTime = entry._LastModified - new System.TimeSpan(1, 0, 0);
        entry._LastModDateTime = Utils.DateTimeToPacked(AdjustedTime);
      }
      else
        entry._LastModDateTime = Utils.DateTimeToPacked(entry._LastModified);

      // we don't actually slurp in the file until the caller invokes Write on this entry.

      return entry;
    }

    public void Extract()
    {
      Extract(".");
    }

    public bool Extract(Stream output)
    {
      try
      {
        using (MemoryStream memstream = new MemoryStream(_FileData))
        {
          using (DeflateStream input = new DeflateStream(memstream, CompressionMode.Decompress))
          {
            byte[] bytes = new byte[4096];
            int n;

            n = 1;
            while (n != 0)
            {
              n = input.Read(bytes, 0, bytes.Length);

              if (n > 0)
                output.Write(bytes, 0, n);
            }

            return true;
          }
        }
      }
      catch (Exception)
      {
        output.Write(_FileData, 0, _FileData.Length);
        return false;
      }
    }

    public void Extract(string basedir)
    {
      string TargetFile = System.IO.Path.Combine(basedir, FileName);

      using (System.IO.MemoryStream memstream = new System.IO.MemoryStream(_FileData))
      {

        using (System.IO.Compression.DeflateStream input =
              new System.IO.Compression.DeflateStream(memstream, System.IO.Compression.CompressionMode.Decompress))
        {

          // ensure the target path exists
          if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(TargetFile)))
          {
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(TargetFile));
          }

          using (System.IO.FileStream output = new System.IO.FileStream(TargetFile, System.IO.FileMode.CreateNew))
          {
            //BinaryWriter w = new BinaryWriter(fs);

            byte[] bytes = new byte[4096];
            int n;

            n = 1; // anything non-zero
            while (n != 0)
            {
              n = input.Read(bytes, 0, bytes.Length);

              if (n > 0)
                output.Write(bytes, 0, n);
            }
          }

          if (LastModified.IsDaylightSavingTime())
            System.IO.File.SetLastWriteTime(TargetFile, LastModified.AddHours(1));
          else
            System.IO.File.SetLastWriteTime(TargetFile, LastModified);

        }
      }
    }


    internal void WriteCentralDirectoryEntry(System.IO.Stream s)
    {
      byte[] bytes = new byte[4096];
      int i = 0;
      // signature
      bytes[i++] = (byte)(ZipDirEntry.ZipDirEntrySignature & 0x000000FF);
      bytes[i++] = (byte)((ZipDirEntry.ZipDirEntrySignature & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((ZipDirEntry.ZipDirEntrySignature & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((ZipDirEntry.ZipDirEntrySignature & 0xFF000000) >> 24);

      // Version Made By
      bytes[i++] = Header[4];
      bytes[i++] = Header[5];

      // Version Needed, Bitfield, compression method, lastmod,
      // crc, sizes, filename length and extra field length -
      // are all the same as the local file header. So just copy them
      int j = 0;
      for (j = 0; j < 26; j++)
        bytes[i + j] = Header[4 + j];

      i += j;  // positioned at next available byte

      // File Comment Length
      bytes[i++] = 0;
      bytes[i++] = 0;

      // Disk number start
      bytes[i++] = 0;
      bytes[i++] = 0;

      // internal file attrs
      // TODO: figure out what is required here. 
      bytes[i++] = 1;
      bytes[i++] = 0;

      // external file attrs
      // TODO: figure out what is required here. 
      bytes[i++] = 0x20;
      bytes[i++] = 0;
      bytes[i++] = 0xb6;
      bytes[i++] = 0x81;

      // relative offset of local header (I think this can be zero)
      bytes[i++] = (byte)(_RelativeOffsetOfHeader & 0x000000FF);
      bytes[i++] = (byte)((_RelativeOffsetOfHeader & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((_RelativeOffsetOfHeader & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((_RelativeOffsetOfHeader & 0xFF000000) >> 24);

      // actual filename (starts at offset 34 in header) 
      for (j = 0; j < Header.Length - 30; j++)
        bytes[i + j] = Header[30 + j];

      i += j;

      s.Write(bytes, 0, i);
    }


    private void WriteHeader(System.IO.Stream s, byte[] bytes)
    {
      // write the header info

      int i = 0;
      // signature
      bytes[i++] = (byte)(ZipEntrySignature & 0x000000FF);
      bytes[i++] = (byte)((ZipEntrySignature & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((ZipEntrySignature & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((ZipEntrySignature & 0xFF000000) >> 24);

      // version needed
      Int16 FixedVersionNeeded = 0x14; // from examining existing zip files
      bytes[i++] = (byte)(FixedVersionNeeded & 0x00FF);
      bytes[i++] = (byte)((FixedVersionNeeded & 0xFF00) >> 8);

      // bitfield
      Int16 BitField = 0x00; // from examining existing zip files
      bytes[i++] = (byte)(BitField & 0x00FF);
      bytes[i++] = (byte)((BitField & 0xFF00) >> 8);

      // compression method
      Int16 CompressionMethod = 0x08; // 0x08 = Deflate
      bytes[i++] = (byte)(CompressionMethod & 0x00FF);
      bytes[i++] = (byte)((CompressionMethod & 0xFF00) >> 8);

      // LastMod
      bytes[i++] = (byte)(_LastModDateTime & 0x000000FF);
      bytes[i++] = (byte)((_LastModDateTime & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((_LastModDateTime & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((_LastModDateTime & 0xFF000000) >> 24);

      // CRC32 (Int32)
      CRC32 crc32 = new CRC32();
      UInt32 crc = 0;
      using (System.IO.Stream input = System.IO.File.OpenRead(FileName))
      {
        crc = crc32.GetCrc32AndCopy(input, CompressedStream);
      }
      CompressedStream.Close();  // to get the footer bytes written to the underlying stream

      bytes[i++] = (byte)(crc & 0x000000FF);
      bytes[i++] = (byte)((crc & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((crc & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((crc & 0xFF000000) >> 24);

      // CompressedSize (Int32)
      Int32 isz = (Int32)_UnderlyingMemoryStream.Length;
      UInt32 sz = (UInt32)isz;
      bytes[i++] = (byte)(sz & 0x000000FF);
      bytes[i++] = (byte)((sz & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((sz & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((sz & 0xFF000000) >> 24);

      // UncompressedSize (Int32)
      bytes[i++] = (byte)(crc32.TotalBytesRead & 0x000000FF);
      bytes[i++] = (byte)((crc32.TotalBytesRead & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((crc32.TotalBytesRead & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((crc32.TotalBytesRead & 0xFF000000) >> 24);

      // filename length (Int16)
      Int16 length = (Int16)FileName.Length;
      bytes[i++] = (byte)(length & 0x00FF);
      bytes[i++] = (byte)((length & 0xFF00) >> 8);

      // extra field length (short)
      Int16 ExtraFieldLength = 0x00;
      bytes[i++] = (byte)(ExtraFieldLength & 0x00FF);
      bytes[i++] = (byte)((ExtraFieldLength & 0xFF00) >> 8);

      // actual filename
      char[] c = FileName.ToCharArray();
      int j = 0;

      for (j = 0; (j < c.Length) && (i + j < bytes.Length); j++)
        bytes[i + j] = System.BitConverter.GetBytes(c[j])[0];

      i += j;

      // extra field (we always write null in this implementation)
      // ;;

      // remember the file offset of this header
      _RelativeOffsetOfHeader = (int)s.Length;

      // finally, write the header to the stream
      s.Write(bytes, 0, i);

      // preserve this header data for use with the central directory structure.
      _header = new byte[i];

      for (j = 0; j < i; j++)
        _header[j] = bytes[j];
    }


    internal void Write(System.IO.Stream s)
    {
      byte[] bytes = new byte[4096];
      int n;

      // write the header:
      WriteHeader(s, bytes);

      // write the actual file data: 
      _UnderlyingMemoryStream.Position = 0;

      while ((n = _UnderlyingMemoryStream.Read(bytes, 0, bytes.Length)) != 0)
        s.Write(bytes, 0, n);

      //_CompressedStream.Close();
      //_CompressedStream= null;
      _UnderlyingMemoryStream.Close();
      _UnderlyingMemoryStream = null;
    }
  }

  public class ZipFile : System.Collections.Generic.IEnumerable<ZipEntry>, IDisposable
  {
    private string _name;
    public string Name
    {
      get { return _name; }
    }

    private System.IO.Stream ReadStream
    {
      get
      {
        return _readstream;
      }
    }

    private System.IO.FileStream WriteStream
    {
      get
      {
        if (_writestream == null)
        {
          _writestream = new System.IO.FileStream(_name, System.IO.FileMode.CreateNew);
        }
        return _writestream;
      }
    }

    private ZipFile() { }


    #region For Writing Zip Files

    public ZipFile(string NewZipFileName)
    {
      // create a new zipfile
      _name = NewZipFileName;
      if (System.IO.File.Exists(_name))
        throw new System.Exception("That file already exists.");
      _entries = new System.Collections.Generic.List<ZipEntry>();
    }


    public void AddFile(string FileName)
    {
      ZipEntry ze = ZipEntry.Create(FileName);
      _entries.Add(ze);
    }

    public void AddDirectory(string DirectoryName)
    {
      String[] filenames = System.IO.Directory.GetFiles(DirectoryName);
      foreach (String filename in filenames)
        AddFile(filename);

      String[] dirnames = System.IO.Directory.GetDirectories(DirectoryName);
      foreach (String dir in dirnames)
        AddDirectory(dir);
    }


    public void Save()
    {
      // an entry for each file
      foreach (ZipEntry e in _entries)
      {
        e.Write(WriteStream);
      }

      WriteCentralDirectoryStructure();
      WriteStream.Close();
      _writestream = null;
    }


    private void WriteCentralDirectoryStructure()
    {
      // the central directory structure
      long Start = WriteStream.Length;
      foreach (ZipEntry e in _entries)
      {
        e.WriteCentralDirectoryEntry(WriteStream);
      }
      long Finish = WriteStream.Length;

      // now, the footer
      WriteCentralDirectoryFooter(Start, Finish);
    }


    private void WriteCentralDirectoryFooter(long StartOfCentralDirectory, long EndOfCentralDirectory)
    {
      byte[] bytes = new byte[1024];
      int i = 0;
      // signature
      UInt32 EndOfCentralDirectorySignature = 0x06054b50;
      bytes[i++] = (byte)(EndOfCentralDirectorySignature & 0x000000FF);
      bytes[i++] = (byte)((EndOfCentralDirectorySignature & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((EndOfCentralDirectorySignature & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((EndOfCentralDirectorySignature & 0xFF000000) >> 24);

      // number of this disk
      bytes[i++] = 0;
      bytes[i++] = 0;

      // number of the disk with the start of the central directory
      bytes[i++] = 0;
      bytes[i++] = 0;

      // total number of entries in the central dir on this disk
      bytes[i++] = (byte)(_entries.Count & 0x00FF);
      bytes[i++] = (byte)((_entries.Count & 0xFF00) >> 8);

      // total number of entries in the central directory
      bytes[i++] = (byte)(_entries.Count & 0x00FF);
      bytes[i++] = (byte)((_entries.Count & 0xFF00) >> 8);

      // size of the central directory
      Int32 SizeOfCentralDirectory = (Int32)(EndOfCentralDirectory - StartOfCentralDirectory);
      bytes[i++] = (byte)(SizeOfCentralDirectory & 0x000000FF);
      bytes[i++] = (byte)((SizeOfCentralDirectory & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((SizeOfCentralDirectory & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((SizeOfCentralDirectory & 0xFF000000) >> 24);

      // offset of the start of the central directory 
      Int32 StartOffset = (Int32)StartOfCentralDirectory;  // cast down from Long
      bytes[i++] = (byte)(StartOffset & 0x000000FF);
      bytes[i++] = (byte)((StartOffset & 0x0000FF00) >> 8);
      bytes[i++] = (byte)((StartOffset & 0x00FF0000) >> 16);
      bytes[i++] = (byte)((StartOffset & 0xFF000000) >> 24);

      // zip comment length
      bytes[i++] = 0;
      bytes[i++] = 0;

      WriteStream.Write(bytes, 0, i);
    }

    #endregion

    #region For Reading Zip Files

    /// <summary>
    /// This will throw if the zipfile does not exist. 
    /// </summary>
    public static ZipFile Read(Stream zipstream)
    {
      ZipFile zf = new ZipFile();
      zf._readstream = zipstream;
      zf._entries = new System.Collections.Generic.List<ZipEntry>();
      ZipEntry e;
      while ((e = ZipEntry.Read(zf.ReadStream)) != null)
      {
        zf._entries.Add(e);
      }

      // read the zipfile's central directory structure here.
      zf._direntries = new System.Collections.Generic.List<ZipDirEntry>();

      ZipDirEntry de;
      while ((de = ZipDirEntry.Read(zf.ReadStream)) != null) { }

      zf._direntries.Add(de);

      return zf;
    }

    public System.Collections.Generic.IEnumerator<ZipEntry> GetEnumerator()
    {
      foreach (ZipEntry e in _entries)
        yield return e;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }


    public void ExtractAll(string path)
    {
      foreach (ZipEntry e in _entries)
      {
        e.Extract(path);
      }
    }


    public void Extract(string filename)
    {
      this[filename].Extract();
    }


    public ZipEntry this[String filename]
    {
      get
      {
        foreach (ZipEntry e in _entries)
        {
          if (e.FileName == filename) return e;
        }
        return null;
      }
    }

    #endregion




    // the destructor
    ~ZipFile()
    {
      // call Dispose with false.  Since we're in the
      // destructor call, the managed resources will be
      // disposed of anyways.
      Dispose(false);
    }

    public void Dispose()
    {
      // dispose of the managed and unmanaged resources
      Dispose(true);

      // tell the GC that the Finalize process no longer needs
      // to be run for this object.
      GC.SuppressFinalize(this);
    }


    protected virtual void Dispose(bool disposeManagedResources)
    {
      if (!this._disposed)
      {
        if (disposeManagedResources)
        {
          // dispose managed resources
          if (_readstream != null)
          {
            _readstream.Dispose();
            _readstream = null;
          }
          if (_writestream != null)
          {
            _writestream.Dispose();
            _writestream = null;
          }
        }
        this._disposed = true;
      }
    }


    private System.IO.Stream _readstream;
    private System.IO.FileStream _writestream;
    private bool _disposed = false;
    private System.Collections.Generic.List<ZipEntry> _entries = null;
    private System.Collections.Generic.List<ZipDirEntry> _direntries = null;
  }
}