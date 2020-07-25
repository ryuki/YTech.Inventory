-- SQL Manager 2005 Lite for SQL Server (2.5.0.1)
-- ---------------------------------------
-- Host      : (local)\SQLExpress
-- Database  : INVENTORI
-- Version   : Microsoft SQL Server  9.00.1399.06

--
-- Definition for table ITEM_GUDANG_STOK : 
--

CREATE TABLE [dbo].[ITEM_GUDANG_STOK] (
  [ITEM_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [GUDANG_ID] int NOT NULL,
  [ITEM_STOK] numeric(18, 0) NULL,
  [ITEM_MIN_STOK] numeric(18, 0) NULL,
  [ITEM_MAX_STOK] numeric(18, 0) NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_BANK : 
--

CREATE TABLE [dbo].[M_BANK] (
  [BANK_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [BANK_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BANK_ADDRESS] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BANK_LIMIT_GIRO_PER_MONTH] numeric(18, 0) NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_CUSTOMER : 
--

CREATE TABLE [dbo].[M_CUSTOMER] (
  [CUSTOMER_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [CUSTOMER_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CUSTOMER_ADDRESS] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CUSTOMER_PHONE] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CUSTOMER_STATUS] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CUSTOMER_DISC] numeric(18, 0) NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_DEP : 
--

CREATE TABLE [dbo].[M_DEP] (
  [DEP_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [DEP_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DEP_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_DESK : 
--

CREATE TABLE [dbo].[M_DESK] (
  [DESK_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [DESK_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_DESC] text COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_ORDER] int NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]


--
-- Definition for table M_DISCOUNT : 
--

CREATE TABLE [dbo].[M_DISCOUNT] (
  [DISC_ID] numeric(18, 0) IDENTITY(1, 1) NOT NULL,
  [DISC] numeric(18, 0) NULL,
  [DISC_DAY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DISC_TIME_HOUR_FROM] int NULL,
  [DISC_TIME_MIN_FROM] int NULL,
  [DISC_TIME_HOUR_TO] int NULL,
  [DISC_TIME_MIN_TO] int NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_EMPLOYEE : 
--

CREATE TABLE [dbo].[M_EMPLOYEE] (
  [EMPLOYEE_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [EMPLOYEE_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DEP_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_GENDER] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_ID_CARD] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_ADDRESS] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_PHONE] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_BIRTH_PLACE] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_BIRTH_DATE] datetime NULL,
  [EMPLOYEE_MARITAL_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_START_WORK] datetime NULL,
  [EMPLOYEE_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_GROUP : 
--

CREATE TABLE [dbo].[M_GROUP] (
  [GROUP_ID] int IDENTITY(1, 1) NOT NULL,
  [GROUP_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_GUDANG : 
--

CREATE TABLE [dbo].[M_GUDANG] (
  [GUDANG_ID] int IDENTITY(1, 1) NOT NULL,
  [LOCATION_ID] int NULL,
  [GUDANG_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_ITEM : 
--

CREATE TABLE [dbo].[M_ITEM] (
  [ITEM_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ITEM_TYPE_ID] int NULL,
  [GROUP_ID] int NULL,
  [ITEM_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ITEM_SATUAN] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ITEM_DESC] text COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ITEM_COMMISION] numeric(18, 0) NULL,
  [DEFAULT_GUDANG_ID] int NULL,
  [ITEM_PRICE_MAX_VIP] numeric(18, 0) NULL,
  [ITEM_PRICE_MIN_VIP] numeric(18, 0) NULL,
  [ITEM_PRICE_MAX] numeric(18, 0) NULL,
  [ITEM_PRICE_MIN] numeric(18, 0) NULL,
  [ITEM_PRICE_PURCHASE] numeric(18, 0) NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]


--
-- Definition for table M_ITEM_TYPE : 
--

CREATE TABLE [dbo].[M_ITEM_TYPE] (
  [ITEM_TYPE_ID] int IDENTITY(1, 1) NOT NULL,
  [ITEM_TYPE_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_LOCATION : 
--

CREATE TABLE [dbo].[M_LOCATION] (
  [LOCATION_ID] int NOT NULL,
  [LOCATION_PARENT_ID] int NOT NULL,
  [LOCATION_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOCATION_SHORT_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOCATION_DESC] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOCATION_IS_CRITICAL] bit NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_MENU : 
--

CREATE TABLE [dbo].[M_MENU] (
  [MENU_ID] numeric(18, 0) NOT NULL,
  [SETTING_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [MENU_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MENU_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table M_SETTING : 
--

CREATE TABLE [dbo].[M_SETTING] (
  [SETTING_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [COMPANY_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [COMPANY_ADDRESS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [COMPANY_CITY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [COMPANY_TELP] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [AUTO_PRINT_SALES] bit NULL,
  [AUTO_BACKUP] bit NULL,
  [BACKUP_DIR] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [FACTUR_NO_FORMAT] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [FACTUR_NO_LENGTH] int NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_SUPPLIER : 
--

CREATE TABLE [dbo].[M_SUPPLIER] (
  [SUPPLIER_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [SUPPLIER_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SUPPLIER_ADDRESS] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SUPPLIER_PHONE] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SUPPLIER_CONTACT] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SUPPLIER_CONTACT_PHONE] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table M_SUPPLIER_ACCOUNT : 
--

CREATE TABLE [dbo].[M_SUPPLIER_ACCOUNT] (
  [SUPPLIER_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [CURRENCY_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [BANK_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SUPPLIER_ACCOUNT_NO] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SUPPLIER_ACCOUNT_NAME] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table M_USER : 
--

CREATE TABLE [dbo].[M_USER] (
  [USER_NAME] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [USER_PASSWORD] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [USER_STATUS] bit NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_BILLIARD_SETTING : 
--

CREATE TABLE [dbo].[T_BILLIARD_SETTING] (
  [SETTING_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [BILIARD_ITEM_PRICE] numeric(18, 0) NULL,
  [BILIARD_ITEM_PRICE_VIP] numeric(18, 0) NULL,
  [BILIARD_ITEM_PRICE_MINI] numeric(18, 0) NULL,
  [QUIT_TIMEOUT] numeric(18, 0) NULL,
  [MINIMUM_PLAY] numeric(18, 0) NULL,
  [FULLFILL_PRICE] numeric(18, 0) NULL,
  [REFEREE_BONUS] numeric(18, 0) NULL,
  [BACK_COLOR] int NULL,
  [DESK_BACK_COLOR] int NULL,
  [DESK_FONT_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_FONT_SIZE] numeric(18, 0) NULL,
  [DESK_FONT_BOLD] bit NULL,
  [DESK_FONT_ITALIC] bit NULL,
  [DESK_FONT_UNDERLINE] bit NULL,
  [DESK_FONT_COLOR] int NULL,
  [DESK_WIDTH] int NULL,
  [DESK_HEIGHT] int NULL,
  [DESK_BACK_COLOR1] int NULL,
  [DESK_FONT_NAME1] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_FONT_SIZE1] numeric(18, 0) NULL,
  [DESK_FONT_BOLD1] bit NULL,
  [DESK_FONT_ITALIC1] bit NULL,
  [DESK_FONT_UNDERLINE1] bit NULL,
  [DESK_FONT_COLOR1] int NULL,
  [DESK_WIDTH1] int NULL,
  [DESK_HEIGHT1] int NULL,
  [DESK_BACK_COLOR2] int NULL,
  [DESK_FONT_NAME2] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_FONT_SIZE2] numeric(18, 0) NULL,
  [DESK_FONT_BOLD2] bit NULL,
  [DESK_FONT_ITALIC2] bit NULL,
  [DESK_FONT_UNDERLINE2] bit NULL,
  [DESK_FONT_COLOR2] int NULL,
  [DESK_WIDTH2] int NULL,
  [DESK_HEIGHT2] int NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_CAFE_SETTING : 
--

CREATE TABLE [dbo].[T_CAFE_SETTING] (
  [SETTING_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [EXPORTED_DIR] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DISCOUNT_PASSWORD] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TELP_NO_SARAN_KRITIK] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_CONTRACTOR_SETTING : 
--

CREATE TABLE [dbo].[T_CONTRACTOR_SETTING] (
  [SETTING_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [DELETE_PIN] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table T_DESK : 
--

CREATE TABLE [dbo].[T_DESK] (
  [T_DESK_ID] numeric(18, 0) IDENTITY(1, 1) NOT NULL,
  [DESK_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_BOOKING_DATE] datetime NULL,
  [DESK_IN_DATE] datetime NULL,
  [DESK_OUT_DATE] datetime NULL,
  [DESK_CUST_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_LONG_PLAY_MINUTES] numeric(18, 0) NULL,
  [DESK_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_TRANSACTION_ID] numeric(18, 0) NULL,
  [DESK_GRAND_TOTAL] numeric(18, 0) NULL,
  [EMPLOYEE_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_GIRO : 
--

CREATE TABLE [dbo].[T_GIRO] (
  [BANK_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [GIRO_NO] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [GIRO_OUT_DATE] datetime NULL,
  [GIRO_MATURITY_DATE] datetime NULL,
  [GIRO_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GIRO_TO] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GIRO_FROM] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GIRO_CAIR_DATE] datetime NULL,
  [GIRO_AMMOUNT] numeric(18, 0) NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_LOG : 
--

CREATE TABLE [dbo].[T_LOG] (
  [LOG_DATE] datetime NOT NULL,
  [LOG_USER] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOG_COMP_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOG_IP] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOG_ACTION] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOG_TABLE] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LOG_DESC] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table T_MENU_USER : 
--

CREATE TABLE [dbo].[T_MENU_USER] (
  [MENU_ID] numeric(18, 0) NOT NULL,
  [USER_NAME] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [SETTING_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [HAS_ACCESS] bit NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_REKAP_COMMISSION : 
--

CREATE TABLE [dbo].[T_REKAP_COMMISSION] (
  [REKAP_DATE_FROM] datetime NOT NULL,
  [REKAP_DATE_TO] datetime NULL,
  [EMPLOYEE_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [REKAP_TOTAL_DURATION] numeric(18, 4) NULL,
  [REFEREE_PRICE] numeric(18, 0) NULL,
  [REFEREE_PRICE_VIP] numeric(18, 0) NULL,
  [REKAP_BONUS] numeric(18, 0) NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_REKAP_TRANSACTION : 
--

CREATE TABLE [dbo].[T_REKAP_TRANSACTION] (
  [REKAP_DATE_FROM] datetime NOT NULL,
  [REKAP_DATE_TO] datetime NULL,
  [DESK_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TOTAL_SALES] numeric(18, 0) NULL,
  [TOTAL_SALES_VIP] numeric(18, 0) NULL,
  [TOTAL_PURCHASE] numeric(18, 0) NULL,
  [TOTAL_RETUR_SALES] numeric(18, 0) NULL,
  [TOTAL_RETUR_SALES_VIP] numeric(18, 0) NULL,
  [TOTAL_RETUR_PURCHASE] numeric(18, 0) NULL,
  [TOTAL_CORRECTION] numeric(18, 0) NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_STOK_CARD : 
--

CREATE TABLE [dbo].[T_STOK_CARD] (
  [STOK_CARD_ID] numeric(18, 0) IDENTITY(1, 1) NOT NULL,
  [ITEM_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GUDANG_ID] int NULL,
  [STOK_CARD_DATE] datetime NULL,
  [TRANSACTION_ID] numeric(18, 0) NULL,
  [STOK_CARD_STATUS] bit NULL,
  [STOK_CARD_QUANTITY] numeric(18, 0) NULL,
  [STOK_CARD_SALDO] numeric(18, 0) NULL,
  [STOK_CARD_PIC] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_TRANSACTION : 
--

CREATE TABLE [dbo].[T_TRANSACTION] (
  [TRANSACTION_ID] decimal(18, 0) NOT NULL,
  [TRANSACTION_REFERENCE_ID] decimal(18, 0) NULL,
  [TRANSACTION_FACTUR] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TRANSACTION_BY] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TRANSACTION_DATE] datetime NULL,
  [TRANSACTION_SUB_TOTAL] numeric(18, 0) NULL,
  [TRANSACTION_DISC] numeric(18, 0) NULL,
  [TRANSACTION_PPN] numeric(18, 0) NULL,
  [TRANSACTION_GRAND_TOTAL] numeric(18, 0) NULL,
  [TRANSACTION_PAID] numeric(18, 0) NULL,
  [TRANSACTION_SISA] numeric(18, 0) NULL,
  [TRANSACTION_STATUS] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TRANSACTION_DESK] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EMPLOYEE_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Definition for table T_TRANSACTION_DETAIL : 
--

CREATE TABLE [dbo].[T_TRANSACTION_DETAIL] (
  [TRANSACTION_DETAIL_ID] numeric(18, 0) IDENTITY(1, 1) NOT NULL,
  [TRANSACTION_ID] numeric(18, 0) NULL,
  [ITEM_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [QUANTITY] numeric(18, 4) NULL,
  [PRICE] numeric(18, 0) NULL,
  [JUMLAH] numeric(18, 0) NULL,
  [DISC] numeric(18, 0) NULL,
  [PPN] numeric(18, 0) NULL,
  [TOTAL] numeric(18, 0) NULL,
  [DESCRIPTION] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [MODIFIED_BY] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MODIFIED_DATE] datetime NULL
)
ON [PRIMARY]


--
-- Data for table M_CUSTOMER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_CUSTOMER] ([CUSTOMER_ID], [CUSTOMER_NAME], [CUSTOMER_ADDRESS], [CUSTOMER_PHONE], [CUSTOMER_STATUS], [CUSTOMER_DISC], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('CASH', 'CASH', '', '', 'Active', 0, 'admin', '20070505 09:30:33.983')


COMMIT


--
-- Data for table M_DEP  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_DEP] ([DEP_ID], [DEP_NAME], [DEP_STATUS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('WASIT', 'WASIT', '', 'lbl_UserName', '20070617 12:52:33')


COMMIT


--
-- Data for table M_DESK  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('1', 'Active', '', 1, '1', '20070609 07:21:45')


COMMIT


--
-- Data for table M_EMPLOYEE  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID], [EMPLOYEE_NAME], [DEP_ID], [EMPLOYEE_GENDER], [EMPLOYEE_ID_CARD], [EMPLOYEE_ADDRESS], [EMPLOYEE_PHONE], [EMPLOYEE_BIRTH_PLACE], [EMPLOYEE_BIRTH_DATE], [EMPLOYEE_MARITAL_STATUS], [EMPLOYEE_START_WORK], [EMPLOYEE_STATUS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('sasa', 'sasa', 'WASIT', 'Pria', 'sasa', 'sasa', 'sasa', 'sasa', '20070618 12:52:52', 'Kawin', '20070617 12:52:52', 'Kontrak', 'admin', '20070617 12:53:11')


COMMIT


--
-- Data for table M_GROUP  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[M_GROUP] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[M_GROUP] ([GROUP_ID], [GROUP_NAME], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (1, 'SPARE PARTS', '1', '20070517 14:53:13')


COMMIT


SET IDENTITY_INSERT [dbo].[M_GROUP] OFF


--
-- Data for table M_GUDANG  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[M_GUDANG] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[M_GUDANG] ([GUDANG_ID], [LOCATION_ID], [GUDANG_NAME], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (1, 0, 'Pekanbaru', 'lbl_UserName', '20070514 14:05:17')


COMMIT


SET IDENTITY_INSERT [dbo].[M_GUDANG] OFF


--
-- Data for table M_ITEM_TYPE  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[M_ITEM_TYPE] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[M_ITEM_TYPE] ([ITEM_TYPE_ID], [ITEM_TYPE_NAME], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (1, 'BARANG', 'admin', '20070505 09:30:08.700')


INSERT INTO [dbo].[M_ITEM_TYPE] ([ITEM_TYPE_ID], [ITEM_TYPE_NAME], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (2, 'JASA', 'admin', '20070505 09:30:08.700')


COMMIT


SET IDENTITY_INSERT [dbo].[M_ITEM_TYPE] OFF


--
-- Data for table M_MENU  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (101, 'Billiard Management Software', 'Golongan Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (101, 'Cafe Management Software', 'Golongan Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (101, 'Contractor Management Software', 'Golongan Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (102, 'Billiard Management Software', 'Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (102, 'Cafe Management Software', 'Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (102, 'Contractor Management Software', 'Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (103, 'Billiard Management Software', 'Pelanggan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (103, 'Cafe Management Software', 'Pelanggan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (103, 'Contractor Management Software', 'Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (104, 'Billiard Management Software', 'Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (104, 'Cafe Management Software', 'Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (104, 'Contractor Management Software', 'Karyawan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (105, 'Billiard Management Software', 'Karyawan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (105, 'Cafe Management Software', 'Meja', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (105, 'Contractor Management Software', 'Bagian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (106, 'Billiard Management Software', 'Bagian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (106, 'Contractor Management Software', 'Bank', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (107, 'Billiard Management Software', 'Meja Billiard', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (107, 'Contractor Management Software', 'Gudang', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (201, 'Billiard Management Software', 'Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (201, 'Cafe Management Software', 'Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (201, 'Contractor Management Software', 'Pemakaian Spare Parts', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (202, 'Billiard Management Software', 'Retur Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (202, 'Cafe Management Software', 'Retur Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (202, 'Contractor Management Software', 'Order Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (203, 'Billiard Management Software', 'Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (203, 'Cafe Management Software', 'Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (203, 'Contractor Management Software', 'Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (204, 'Billiard Management Software', 'Retur Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (204, 'Cafe Management Software', 'Retur Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (204, 'Contractor Management Software', 'Retur Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (205, 'Billiard Management Software', 'Penyesuaian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (205, 'Cafe Management Software', 'Penyesuaian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (205, 'Contractor Management Software', 'Penyesuaian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (206, 'Billiard Management Software', 'Billiard', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (206, 'Cafe Management Software', 'Cafe', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (206, 'Contractor Management Software', 'Giro', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (301, 'Billiard Management Software', 'Daftar Golongan Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (301, 'Cafe Management Software', 'Daftar Golongan Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (301, 'Contractor Management Software', 'Daftar Golongan Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (302, 'Billiard Management Software', 'Daftar Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (302, 'Cafe Management Software', 'Daftar Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (302, 'Contractor Management Software', 'Daftar Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (303, 'Billiard Management Software', 'Daftar Pelanggan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (303, 'Cafe Management Software', 'Daftar Pelanggan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (303, 'Contractor Management Software', 'Daftar Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (304, 'Billiard Management Software', 'Daftar Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (304, 'Cafe Management Software', 'Daftar Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (304, 'Contractor Management Software', 'Daftar Karyawan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (305, 'Billiard Management Software', 'Daftar Bagian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (306, 'Billiard Management Software', 'Daftar Karyawan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (306, 'Cafe Management Software', 'Laporan Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (306, 'Contractor Management Software', 'Laporan Pemakaian Spare Parts', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (307, 'Cafe Management Software', 'Laporan Retur Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (308, 'Billiard Management Software', 'Laporan Total Penjualan Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (308, 'Contractor Management Software', 'Laporan Order Pembelian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (309, 'Billiard Management Software', 'Laporan Total Penjualan VIP Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (309, 'Cafe Management Software', 'Laporan Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (309, 'Contractor Management Software', 'Laporan Order Pembelian Per Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (310, 'Billiard Management Software', 'Laporan Total Penjualan Per Meja', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (310, 'Cafe Management Software', 'Laporan Retur Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (310, 'Contractor Management Software', 'Laporan Pembelian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (311, 'Billiard Management Software', 'Laporan Total Penjualan VIP Per Meja', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (311, 'Cafe Management Software', 'Laporan Penyesuaian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (311, 'Contractor Management Software', 'Laporan Pembelian Per Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (312, 'Billiard Management Software', 'Laporan Detail Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (312, 'Contractor Management Software', 'Laporan Retur Pembelian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (313, 'Billiard Management Software', 'Laporan Detail Penjualan VIP', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (313, 'Contractor Management Software', 'Laporan Retur Pembelian Per Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (314, 'Billiard Management Software', 'Laporan Total Retur Penjualan Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (314, 'Contractor Management Software', 'Laporan Penyesuaian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (315, 'Billiard Management Software', 'Laporan Detail Retur Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (316, 'Contractor Management Software', 'Laporan Giro Per Bank', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (317, 'Billiard Management Software', 'Laporan Total Pembelian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (317, 'Contractor Management Software', 'Laporan Giro Per Jatuh Tempo', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (318, 'Billiard Management Software', 'Laporan Detail Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (318, 'Contractor Management Software', 'Laporan Giro Per Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (319, 'Billiard Management Software', 'Laporan Total Retur Pembelian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (320, 'Billiard Management Software', 'Laporan Detail Retur Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (322, 'Billiard Management Software', 'Laporan Total Penyesuaian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (323, 'Billiard Management Software', 'Laporan Detail Penyesuaian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (324, 'Billiard Management Software', 'Laporan Rekap Komisi Wasit', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (401, 'Billiard Management Software', 'Tutup Hari', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (401, 'Cafe Management Software', 'Tutup Periode', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (401, 'Contractor Management Software', 'Backup Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (402, 'Billiard Management Software', 'Backup Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (402, 'Cafe Management Software', 'Backup Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (402, 'Contractor Management Software', 'Restore Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (403, 'Billiard Management Software', 'Restore Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (403, 'Cafe Management Software', 'Restore Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (403, 'Contractor Management Software', 'Konfigurasi Program', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (404, 'Billiard Management Software', 'Konfigurasi Program', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (404, 'Cafe Management Software', 'Konfigurasi Program', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (404, 'Contractor Management Software', 'Daftar Pengguna', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (405, 'Billiard Management Software', 'Daftar Pengguna', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (405, 'Cafe Management Software', 'Daftar Pengguna', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (405, 'Contractor Management Software', 'Ganti Kata Kunci', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (406, 'Billiard Management Software', 'Diskon Global', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (406, 'Cafe Management Software', 'Ganti Password', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (407, 'Billiard Management Software', 'Ganti Password', 'OK')


COMMIT


--
-- Data for table M_SETTING  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_SETTING] ([SETTING_ID], [COMPANY_NAME], [COMPANY_ADDRESS], [COMPANY_CITY], [COMPANY_TELP], [AUTO_PRINT_SALES], [AUTO_BACKUP], [BACKUP_DIR], [FACTUR_NO_FORMAT], [FACTUR_NO_LENGTH], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('Billiard Management Software', 'NINE BALL BILLIARD', 'Jln Sultan Syarif Qasim', 'Pekanbaru', '(0761) 923053', 0, 0, 'E:\My Project\Inventori', '[xxx]/[meja]', 6, 'admin', '20070515 17:29:45')


INSERT INTO [dbo].[M_SETTING] ([SETTING_ID], [COMPANY_NAME], [COMPANY_ADDRESS], [COMPANY_CITY], [COMPANY_TELP], [AUTO_PRINT_SALES], [AUTO_BACKUP], [BACKUP_DIR], [FACTUR_NO_FORMAT], [FACTUR_NO_LENGTH], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('Cafe Management Software', 'Kedai Kopi VID', 'Riau Bussiness Center', 'Pekanbaru', '(0761) 555999', 0, 0, '', '[xxx]/[meja]', 5, 'admin', '20070505 09:30:03.480')


INSERT INTO [dbo].[M_SETTING] ([SETTING_ID], [COMPANY_NAME], [COMPANY_ADDRESS], [COMPANY_CITY], [COMPANY_TELP], [AUTO_PRINT_SALES], [AUTO_BACKUP], [BACKUP_DIR], [FACTUR_NO_FORMAT], [FACTUR_NO_LENGTH], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('Contractor Management Software', 'CV. Sejahtera', 'Jalan Arengka No. 6E', 'Pekanbaru - Riau', '(0761) 33998 / 33996   Fax : (0761) 572276', 0, 0, '', '[xxx]/[TipeTransaksi]/[tahun]', 3, '1', '20070615 21:23:23')


COMMIT


--
-- Data for table M_SUPPLIER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_SUPPLIER] ([SUPPLIER_ID], [SUPPLIER_NAME], [SUPPLIER_ADDRESS], [SUPPLIER_PHONE], [SUPPLIER_CONTACT], [SUPPLIER_CONTACT_PHONE], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('CASH', 'CASH', '', '', '', '', '1', '20070518 17:46:14')


COMMIT


--
-- Data for table M_USER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('admin', 'admin', 1, 'lbl_UserName', '20070617 12:02:59')


COMMIT


--
-- Data for table T_BILLIARD_SETTING  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[T_BILLIARD_SETTING] ([SETTING_ID], [BILIARD_ITEM_PRICE], [BILIARD_ITEM_PRICE_VIP], [BILIARD_ITEM_PRICE_MINI], [QUIT_TIMEOUT], [MINIMUM_PLAY], [FULLFILL_PRICE], [REFEREE_BONUS], [BACK_COLOR], [DESK_BACK_COLOR], [DESK_FONT_NAME], [DESK_FONT_SIZE], [DESK_FONT_BOLD], [DESK_FONT_ITALIC], [DESK_FONT_UNDERLINE], [DESK_FONT_COLOR], [DESK_WIDTH], [DESK_HEIGHT], [DESK_BACK_COLOR1], [DESK_FONT_NAME1], [DESK_FONT_SIZE1], [DESK_FONT_BOLD1], [DESK_FONT_ITALIC1], [DESK_FONT_UNDERLINE1], [DESK_FONT_COLOR1], [DESK_WIDTH1], [DESK_HEIGHT1], [DESK_BACK_COLOR2], [DESK_FONT_NAME2], [DESK_FONT_SIZE2], [DESK_FONT_BOLD2], [DESK_FONT_ITALIC2], [DESK_FONT_UNDERLINE2], [DESK_FONT_COLOR2], [DESK_WIDTH2], [DESK_HEIGHT2], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  ('Billiard Management Software', 50000, 60000, 40000, 5, 30, 500, 5000, 0, 16777215, 'Arial Black', 11, 0, 0, 0, 0, 70, 45, 8454143, 'Lucida Sans', 11, 0, 0, 0, 33023, 25, 50, 16744448, 'Verdana', 11, 0, 0, 0, 65280, 25, 80, 'admin', '20070515 17:29:45')


COMMIT


--
-- Data for table T_DESK  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[T_DESK] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[T_DESK] ([T_DESK_ID], [DESK_ID], [DESK_BOOKING_DATE], [DESK_IN_DATE], [DESK_OUT_DATE], [DESK_CUST_ID], [DESK_LONG_PLAY_MINUTES], [DESK_STATUS], [DESK_TRANSACTION_ID], [DESK_GRAND_TOTAL], [EMPLOYEE_ID], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (54, '1', '20070617 12:53:37', '20070617 12:53:37', '20070617 12:53:37', 'CASH', 0, 'In', 1.28265332173281E17, 0, 'sasa', 'admin', '20070617 12:54:05')


COMMIT


SET IDENTITY_INSERT [dbo].[T_DESK] OFF


--
-- Data for table T_MENU_USER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (101, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (101, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (102, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (102, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (103, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (103, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (104, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (104, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (105, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (105, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (106, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (106, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (107, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (107, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (201, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (201, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (202, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (202, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (203, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (203, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (204, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (204, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (205, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (205, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (206, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (206, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (301, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (301, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (302, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (302, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (303, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (303, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (304, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (304, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (305, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (306, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (306, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (308, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:02:59')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (308, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (309, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (309, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (310, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (310, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (311, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (311, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (312, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (312, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (313, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (313, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (314, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (314, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (315, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (316, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (317, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (317, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (318, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (318, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (319, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (320, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (322, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (323, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (324, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (401, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (401, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (402, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (402, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (403, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (403, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (404, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (404, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (405, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (405, 'admin', 'Contractor Management Software', 1, 'lbl_UserName', '20070616 10:19:16')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (406, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS], [MODIFIED_BY], [MODIFIED_DATE])
VALUES 
  (407, 'admin', 'Billiard Management Software', 1, 'lbl_UserName', '20070617 12:03:00')


COMMIT


--
-- Definition for indices : 
--

ALTER TABLE [dbo].[ITEM_GUDANG_STOK]
ADD CONSTRAINT [PK_ITEM_GUDANG_STOK_1] 
PRIMARY KEY CLUSTERED ([ITEM_ID], [GUDANG_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_BANK]
ADD CONSTRAINT [PK_M_BANK] 
PRIMARY KEY CLUSTERED ([BANK_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_CUSTOMER]
ADD CONSTRAINT [PK_M_CUSTOMER] 
PRIMARY KEY CLUSTERED ([CUSTOMER_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_DEP]
ADD CONSTRAINT [PK_M_DEP] 
PRIMARY KEY CLUSTERED ([DEP_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_DESK]
ADD CONSTRAINT [PK_M_DESK] 
PRIMARY KEY CLUSTERED ([DESK_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_DISCOUNT]
ADD CONSTRAINT [PK_M_DISCOUNT] 
PRIMARY KEY CLUSTERED ([DISC_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_EMPLOYEE]
ADD CONSTRAINT [PK_M_EMPLOYEE] 
PRIMARY KEY CLUSTERED ([EMPLOYEE_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_GROUP]
ADD CONSTRAINT [PK_M_GROUP] 
PRIMARY KEY CLUSTERED ([GROUP_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_GUDANG]
ADD CONSTRAINT [PK_M_GUDANG] 
PRIMARY KEY CLUSTERED ([GUDANG_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


CREATE NONCLUSTERED INDEX [M_ITEM_INDEX1] ON [dbo].[M_ITEM]
  ([ITEM_TYPE_ID], [GROUP_ID])
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]


ALTER TABLE [dbo].[M_ITEM]
ADD CONSTRAINT [PK_M_ITEM_1] 
PRIMARY KEY CLUSTERED ([ITEM_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_ITEM_TYPE]
ADD CONSTRAINT [PK_M_ITEM_TYPE] 
PRIMARY KEY CLUSTERED ([ITEM_TYPE_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_LOCATION]
ADD CONSTRAINT [PK_M_LOCATION] 
PRIMARY KEY CLUSTERED ([LOCATION_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_MENU]
ADD CONSTRAINT [PK_M_MENU] 
PRIMARY KEY CLUSTERED ([MENU_ID], [SETTING_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_SETTING]
ADD CONSTRAINT [PK_M_SETTING] 
PRIMARY KEY CLUSTERED ([SETTING_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_SUPPLIER]
ADD CONSTRAINT [PK_M_SUPPLIER] 
PRIMARY KEY CLUSTERED ([SUPPLIER_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_SUPPLIER_ACCOUNT]
ADD CONSTRAINT [PK_M_SUPPLIER_ACCOUNT_1] 
PRIMARY KEY CLUSTERED ([SUPPLIER_ID], [CURRENCY_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[M_USER]
ADD CONSTRAINT [PK_M_USER] 
PRIMARY KEY CLUSTERED ([USER_NAME])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_BILLIARD_SETTING]
ADD CONSTRAINT [PK_T_BILLIARD_SETTING] 
PRIMARY KEY CLUSTERED ([SETTING_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_CAFE_SETTING]
ADD CONSTRAINT [PK_T_CAFE_SETTING] 
PRIMARY KEY CLUSTERED ([SETTING_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_CONTRACTOR_SETTING]
ADD CONSTRAINT [PK_T_CONTRACTOR_SETTING] 
PRIMARY KEY CLUSTERED ([SETTING_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_DESK]
ADD CONSTRAINT [PK_T_DESK] 
PRIMARY KEY CLUSTERED ([T_DESK_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


CREATE NONCLUSTERED INDEX [T_DESK_INDEX1] ON [dbo].[T_DESK]
  ([DESK_ID], [DESK_CUST_ID], [DESK_STATUS], [DESK_TRANSACTION_ID], [EMPLOYEE_ID])
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_GIRO]
ADD CONSTRAINT [PK_T_GIRO] 
PRIMARY KEY CLUSTERED ([BANK_ID], [GIRO_NO])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_LOG]
ADD CONSTRAINT [PK_T_LOG] 
PRIMARY KEY CLUSTERED ([LOG_DATE])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_MENU_USER]
ADD CONSTRAINT [PK_T_MENU_USER] 
PRIMARY KEY CLUSTERED ([MENU_ID], [USER_NAME], [SETTING_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_REKAP_COMMISSION]
ADD CONSTRAINT [PK_T_REKAP_COMMISSION] 
PRIMARY KEY CLUSTERED ([REKAP_DATE_FROM], [EMPLOYEE_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_REKAP_TRANSACTION]
ADD CONSTRAINT [PK_T_REKAP_TRANSACTION] 
PRIMARY KEY CLUSTERED ([REKAP_DATE_FROM])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_STOK_CARD]
ADD CONSTRAINT [PK_T_STOK_CARD] 
PRIMARY KEY CLUSTERED ([STOK_CARD_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_TRANSACTION]
ADD CONSTRAINT [PK_TRANSACTION] 
PRIMARY KEY CLUSTERED ([TRANSACTION_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


ALTER TABLE [dbo].[T_TRANSACTION_DETAIL]
ADD CONSTRAINT [PK_TRANSACTION_DETAIL] 
PRIMARY KEY CLUSTERED ([TRANSACTION_DETAIL_ID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


CREATE NONCLUSTERED INDEX [T_TRANSACTION_DETAIL_INDEX1] ON [dbo].[T_TRANSACTION_DETAIL]
  ([TRANSACTION_ID], [ITEM_ID])
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]


