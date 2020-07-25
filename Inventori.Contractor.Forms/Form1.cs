using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventori.Contractor.Forms
{
	// Written by Fernando Felman, http://fernandof.wordpress.com
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		#region GUI events

		private void btnStartStop_Click(object sender, EventArgs e)
		{
			if (!wrkPrimeNumbers.IsBusy)
			{
				// starting new work - resest objects
				this.pgbTestedNumbers.Value = this.pgbTestedNumbers.Minimum;
				this.trbNumbersFound.Clear();

				// start the worker
				int maxNumToTest = (int)this.nupLimit.Value;
				this.wrkPrimeNumbers.RunWorkerAsync(maxNumToTest);
			}
			else
			{
				// canceling current work
				this.wrkPrimeNumbers.CancelAsync();
			}
		}

		#endregion

		#region worker events and helpers

		/// <summary>
		/// Handles the DoWork event of the wrkPrimeNumbers control.
		/// This method will test all numbers from 2..e.Argument for prime numbers.
		/// Status updates will be sent for each number tested.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void wrkPrimeNumbers_DoWork(object sender, DoWorkEventArgs e)
		{
			int limit = (int)e.Argument;

			int foundPrimeNumbers = 0;
			for (int currNumber = 2; currNumber < limit; currNumber++)
			{
				if (wrkPrimeNumbers.CancellationPending)
				{
					// user canceled
					e.Cancel = true;
					break;
				}

				// test current number
				int? currPrimeNumber = null;
				if (IsPrimeNumber(currNumber))
				{
					foundPrimeNumbers++;
					currPrimeNumber = currNumber;
				}


				// Report progress to listeners
				int progressPercentage = ((100 * currNumber) / (limit - 2));
				wrkPrimeNumbers.ReportProgress(progressPercentage, currPrimeNumber);
			}

			e.Result = foundPrimeNumbers;
		}

		/// <summary>
		/// Handles the ProgressChanged event of the wrkPrimeNumbers control.
		/// This method will be called using the GUI thread that created the component.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">
		/// The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.
		/// </param>
		private void wrkPrimeNumbers_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// update the progress bar
			this.pgbTestedNumbers.Value = e.ProgressPercentage;

			// show prime number
			if (e.UserState != null && this.chxShowControls.Checked)
			{
				this.trbNumbersFound.AppendText(string.Format("{0}, ", e.UserState));
			}
		}

		/// <summary>
		/// Handles the RunWorkerCompleted event of the wrkPrimeNumbers control.
		/// This method will be called using the GUI thread that created the component.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void wrkPrimeNumbers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// show process complete details
			StringBuilder msg = new StringBuilder("Worker completed. Details:\r\n");
			msg.AppendFormat("User Canceled: {0}\r\n", e.Cancelled);
			msg.AppendFormat("Error: {0}\r\n", e.Error != null ? e.Error.Message : "none");
			MessageBox.Show(msg.ToString());

			if (!e.Cancelled && e.Error == null)
			{
				this.trbNumbersFound.AppendText
					(string.Format("\r\nFound {0} prime numbers", e.Result));
			}
			else
			{
				this.trbNumbersFound.AppendText
					("\r\nWork completed abnormally (either cancel or error) - no result to display");
			}
		}

		#endregion

		#region prime numbers helpers

		/// <summary>
		/// Determines whether the specified number is a prime number.
		/// </summary>
		/// <param name="number">The number to test.</param>
		/// <param name="divider">
		/// A valid divider that the non-prime number can be divided by,
		/// or null if the number is a prime number.
		/// </param>
		/// <returns>
		/// 	<c>true</c> if the specified number is a prime number; otherwise, <c>false</c>.
		/// </returns>
		/// <remarks>
		/// For simplicity of sample, numbers smaller than 2 are not handled correctly.
		/// </remarks>
		public static bool IsPrimeNumber(int number, out int? divider)
		{
			divider = null;

			// test for dividers in the range of 2..Sqrt(n)
			int limit = (int)Math.Sqrt(number);
			for (int currDivider = 2; currDivider <= limit; currDivider++)
			{
				if (number % currDivider == 0)
				{
					// valid divider found
					divider = currDivider;
					break;
				}
			}

			// prime numbers don't have dividers
			return divider == null;
		}

		/// <summary>
		/// Determines whether the specified number is a prime number.
		/// </summary>
		/// <param name="number">The number to test.</param>
		/// <returns>
		/// 	<c>true</c> if the specified number is a prime number; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsPrimeNumber(int number)
		{
			int? dividerToVoid;
			return IsPrimeNumber(number, out dividerToVoid);
		}

		#endregion

		#region thread contexts switching sample

		/// <summary>
		/// A sample method demostrating how to switch thread contexts
		/// using anonymous methods.
		/// </summary>
		/// <param name="message">A stringed typed argument.</param>
		/// <param name="sequece">An int typed argument.</param>
		/// <remarks>
		/// This method is not used by the BackroungWorker sample.
		/// It exists for reference only.
		/// </remarks>
		public void UpdateGuiControl(string message, int sequence)
		{
			if (this.InvokeRequired)
			{
				// re-invoke this method using the GUI thread
				MethodInvoker updateGuiContorlsInvoker =
					delegate { UpdateGuiControl(message, sequence); };
				this.Invoke(updateGuiContorlsInvoker);
				return;
			}

			// update the controls as we're using the GUI thread
		}

		#endregion
	}
}