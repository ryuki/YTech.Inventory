-- SQL Manager 2005 Lite for SQL Server (2.5.0.1)
-- ---------------------------------------
-- Host      : (local)\SQLExpress
-- Database  : INVENTORI
-- Version   : Microsoft SQL Server  9.00.1399.06


--
-- Dropping table ITEM_GUDANG_STOK : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[ITEM_GUDANG_STOK]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[ITEM_GUDANG_STOK]


--
-- Dropping table M_CUSTOMER : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_CUSTOMER]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_CUSTOMER]


--
-- Dropping table M_DEP : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_DEP]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_DEP]


--
-- Dropping table M_DESK : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_DESK]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_DESK]


--
-- Dropping table M_DISCOUNT : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_DISCOUNT]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_DISCOUNT]


--
-- Dropping table M_EMPLOYEE : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_EMPLOYEE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_EMPLOYEE]


--
-- Dropping table M_GROUP : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_GROUP]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_GROUP]


--
-- Dropping table M_GUDANG : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_GUDANG]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_GUDANG]


--
-- Dropping table M_ITEM : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_ITEM]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_ITEM]


--
-- Dropping table M_ITEM_TYPE : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_ITEM_TYPE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_ITEM_TYPE]


--
-- Dropping table M_MENU : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_MENU]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_MENU]


--
-- Dropping table M_SETTING : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_SETTING]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_SETTING]


--
-- Dropping table M_SUPPLIER : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_SUPPLIER]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_SUPPLIER]


--
-- Dropping table M_USER : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[M_USER]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[M_USER]


--
-- Dropping table T_BILLIARD_SETTING : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_BILLIARD_SETTING]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_BILLIARD_SETTING]


--
-- Dropping table T_CAFE_SETTING : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_CAFE_SETTING]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_CAFE_SETTING]


--
-- Dropping table T_DESK : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_DESK]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_DESK]


--
-- Dropping table T_LOG : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_LOG]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_LOG]


--
-- Dropping table T_MENU_USER : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_MENU_USER]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_MENU_USER]


--
-- Dropping table T_REKAP_COMMISSION : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_REKAP_COMMISSION]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_REKAP_COMMISSION]


--
-- Dropping table T_REKAP_TRANSACTION : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_REKAP_TRANSACTION]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_REKAP_TRANSACTION]


--
-- Dropping table T_STOK_CARD : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_STOK_CARD]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_STOK_CARD]


--
-- Dropping table T_TRANSACTION : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_TRANSACTION]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_TRANSACTION]


--
-- Dropping table T_TRANSACTION_DETAIL : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[T_TRANSACTION_DETAIL]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE [dbo].[T_TRANSACTION_DETAIL]


--
-- Definition for table ITEM_GUDANG_STOK : 
--

CREATE TABLE [dbo].[ITEM_GUDANG_STOK] (
  [ITEM_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [GUDANG_ID] int NOT NULL,
  [ITEM_STOK] numeric(18, 0) NULL,
  [ITEM_MIN_STOK] numeric(18, 0) NULL,
  [ITEM_MAX_STOK] numeric(18, 0) NULL
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
  [CUSTOMER_DISC] numeric(18, 0) NULL
)
ON [PRIMARY]


--
-- Definition for table M_DEP : 
--

CREATE TABLE [dbo].[M_DEP] (
  [DEP_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [DEP_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DEP_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table M_DESK : 
--

CREATE TABLE [dbo].[M_DESK] (
  [DESK_ID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [DESK_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_DESC] text COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DESK_ORDER] int NULL
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
  [DISC_TIME_MIN_TO] int NULL
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
  [EMPLOYEE_STATUS] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table M_GROUP : 
--

CREATE TABLE [dbo].[M_GROUP] (
  [GROUP_ID] int IDENTITY(1, 1) NOT NULL,
  [GROUP_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table M_GUDANG : 
--

CREATE TABLE [dbo].[M_GUDANG] (
  [GUDANG_ID] int IDENTITY(1, 1) NOT NULL,
  [GUDANG_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
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
  [ITEM_PRICE_PURCHASE] numeric(18, 0) NULL
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]


--
-- Definition for table M_ITEM_TYPE : 
--

CREATE TABLE [dbo].[M_ITEM_TYPE] (
  [ITEM_TYPE_ID] int IDENTITY(1, 1) NOT NULL,
  [ITEM_TYPE_NAME] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
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
  [FACTUR_NO_LENGTH] int NULL
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
  [SUPPLIER_CONTACT_PHONE] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table M_USER : 
--

CREATE TABLE [dbo].[M_USER] (
  [USER_NAME] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [USER_PASSWORD] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [USER_STATUS] bit NULL
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
  [DESK_HEIGHT2] int NULL
)
ON [PRIMARY]


--
-- Definition for table T_CAFE_SETTING : 
--

CREATE TABLE [dbo].[T_CAFE_SETTING] (
  [SETTING_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [EXPORTED_DIR] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DISCOUNT_PASSWORD] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
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
  [EMPLOYEE_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
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
  [HAS_ACCESS] bit NULL
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
  [REKAP_BONUS] numeric(18, 0) NULL
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
  [TOTAL_CORRECTION] numeric(18, 0) NULL
)
ON [PRIMARY]


--
-- Definition for table T_STOK_CARD : 
--

CREATE TABLE [dbo].[T_STOK_CARD] (
  [STOK_CARD_ID] numeric(18, 0) IDENTITY(1, 1) NOT NULL,
  [ITEM_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [STOK_CARD_DATE] datetime NULL,
  [TRANSACTION_ID] numeric(18, 0) NULL,
  [STOK_CARD_STATUS] bit NULL,
  [STOK_CARD_QUANTITY] numeric(18, 0) NULL,
  [STOK_CARD_SALDO] numeric(18, 0) NULL,
  [STOK_CARD_PIC] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
ON [PRIMARY]


--
-- Definition for table T_TRANSACTION : 
--

CREATE TABLE [dbo].[T_TRANSACTION] (
  [TRANSACTION_ID] decimal(18, 0) NOT NULL,
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
  [EMPLOYEE_ID] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
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
  [TOTAL] numeric(18, 0) NULL
)
ON [PRIMARY]


--
-- Data for table ITEM_GUDANG_STOK  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[ITEM_GUDANG_STOK] ([ITEM_ID], [GUDANG_ID], [ITEM_STOK], [ITEM_MIN_STOK], [ITEM_MAX_STOK])
VALUES 
  ('AQUA BTL', 1, -10, 45, 45)


INSERT INTO [dbo].[ITEM_GUDANG_STOK] ([ITEM_ID], [GUDANG_ID], [ITEM_STOK], [ITEM_MIN_STOK], [ITEM_MAX_STOK])
VALUES 
  ('MIE GRG', 1, -76, 10, 250)


INSERT INTO [dbo].[ITEM_GUDANG_STOK] ([ITEM_ID], [GUDANG_ID], [ITEM_STOK], [ITEM_MIN_STOK], [ITEM_MAX_STOK])
VALUES 
  ('rokok1', 1, 20, 5, 15)


INSERT INTO [dbo].[ITEM_GUDANG_STOK] ([ITEM_ID], [GUDANG_ID], [ITEM_STOK], [ITEM_MIN_STOK], [ITEM_MAX_STOK])
VALUES 
  ('SAMPOERNA RK', 1, -63, 10, 50)


INSERT INTO [dbo].[ITEM_GUDANG_STOK] ([ITEM_ID], [GUDANG_ID], [ITEM_STOK], [ITEM_MIN_STOK], [ITEM_MAX_STOK])
VALUES 
  ('TEH SOSRO', 1, -163, 10, 250)


COMMIT


--
-- Data for table M_CUSTOMER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_CUSTOMER] ([CUSTOMER_ID], [CUSTOMER_NAME], [CUSTOMER_ADDRESS], [CUSTOMER_PHONE], [CUSTOMER_STATUS], [CUSTOMER_DISC])
VALUES 
  ('CASH', 'CASH', '', '', 'Active', 0)


COMMIT


--
-- Data for table M_DEP  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_DEP] ([DEP_ID], [DEP_NAME], [DEP_STATUS])
VALUES 
  ('KASIR', 'KASIR', 'OK')


INSERT INTO [dbo].[M_DEP] ([DEP_ID], [DEP_NAME], [DEP_STATUS])
VALUES 
  ('SALES', 'SALES', 'OK')


INSERT INTO [dbo].[M_DEP] ([DEP_ID], [DEP_NAME], [DEP_STATUS])
VALUES 
  ('WASIT', 'WASIT', 'OK')


COMMIT


--
-- Data for table M_DESK  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('1', 'Active', '', 1)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('10', 'Active', '', 10)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('2', 'Active', '', 2)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('3', 'Active', '', 3)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('4', 'Active', '', 4)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('5', 'Active', '', 5)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('6', 'Active', '', 6)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('7', 'Active', '', 7)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('8', 'Active', '', 8)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('9', 'Active', '', 9)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('M 1', 'Mini', '', 1)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('M 2', 'Mini', '', 2)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('M 3', 'Mini', '', 3)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('VIP 1', 'VIP', '', 1)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('VIP 2', 'VIP', '', 2)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('VIP 3', 'VIP', '', 3)


INSERT INTO [dbo].[M_DESK] ([DESK_ID], [DESK_STATUS], [DESK_DESC], [DESK_ORDER])
VALUES 
  ('VIP 4', 'VIP', '', 4)


COMMIT


--
-- Data for table M_DISCOUNT  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[M_DISCOUNT] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[M_DISCOUNT] ([DISC_ID], [DISC], [DISC_DAY], [DISC_TIME_HOUR_FROM], [DISC_TIME_MIN_FROM], [DISC_TIME_HOUR_TO], [DISC_TIME_MIN_TO])
VALUES 
  (8, 20, 'Selasa', 10, 0, 23, 59)


INSERT INTO [dbo].[M_DISCOUNT] ([DISC_ID], [DISC], [DISC_DAY], [DISC_TIME_HOUR_FROM], [DISC_TIME_MIN_FROM], [DISC_TIME_HOUR_TO], [DISC_TIME_MIN_TO])
VALUES 
  (9, 10, 'Senin', 18, 0, 19, 0)


INSERT INTO [dbo].[M_DISCOUNT] ([DISC_ID], [DISC], [DISC_DAY], [DISC_TIME_HOUR_FROM], [DISC_TIME_MIN_FROM], [DISC_TIME_HOUR_TO], [DISC_TIME_MIN_TO])
VALUES 
  (10, 23, 'Rabu', 5, 0, 12, 0)


INSERT INTO [dbo].[M_DISCOUNT] ([DISC_ID], [DISC], [DISC_DAY], [DISC_TIME_HOUR_FROM], [DISC_TIME_MIN_FROM], [DISC_TIME_HOUR_TO], [DISC_TIME_MIN_TO])
VALUES 
  (11, 0, 'Jumat', 9, 0, 16, 0)


COMMIT


SET IDENTITY_INSERT [dbo].[M_DISCOUNT] OFF


--
-- Data for table M_EMPLOYEE  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID], [EMPLOYEE_NAME], [DEP_ID], [EMPLOYEE_GENDER], [EMPLOYEE_ID_CARD], [EMPLOYEE_ADDRESS], [EMPLOYEE_PHONE], [EMPLOYEE_BIRTH_PLACE], [EMPLOYEE_BIRTH_DATE], [EMPLOYEE_MARITAL_STATUS], [EMPLOYEE_START_WORK], [EMPLOYEE_STATUS])
VALUES 
  ('4545', '4545', 'SALES', 'Wanita', '', '', '', '', '19890404 18:48:15', 'Tidak Kawin', '20070404 18:48:15', 'Tetap')


INSERT INTO [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID], [EMPLOYEE_NAME], [DEP_ID], [EMPLOYEE_GENDER], [EMPLOYEE_ID_CARD], [EMPLOYEE_ADDRESS], [EMPLOYEE_PHONE], [EMPLOYEE_BIRTH_PLACE], [EMPLOYEE_BIRTH_DATE], [EMPLOYEE_MARITAL_STATUS], [EMPLOYEE_START_WORK], [EMPLOYEE_STATUS])
VALUES 
  ('as', 'test', 'WASIT', 'Wanita', '', '', '', '', '19890404 18:48:15', 'Tidak Kawin', '20070404 18:48:15', 'Tetap')


INSERT INTO [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID], [EMPLOYEE_NAME], [DEP_ID], [EMPLOYEE_GENDER], [EMPLOYEE_ID_CARD], [EMPLOYEE_ADDRESS], [EMPLOYEE_PHONE], [EMPLOYEE_BIRTH_PLACE], [EMPLOYEE_BIRTH_DATE], [EMPLOYEE_MARITAL_STATUS], [EMPLOYEE_START_WORK], [EMPLOYEE_STATUS])
VALUES 
  ('ASA', 'ASA', 'WASIT', 'Wanita', '32', 'ssq', '234', 'dfg', '19890404 18:48:15', 'Tidak Kawin', '20070404 18:48:15', 'Tetap')


INSERT INTO [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID], [EMPLOYEE_NAME], [DEP_ID], [EMPLOYEE_GENDER], [EMPLOYEE_ID_CARD], [EMPLOYEE_ADDRESS], [EMPLOYEE_PHONE], [EMPLOYEE_BIRTH_PLACE], [EMPLOYEE_BIRTH_DATE], [EMPLOYEE_MARITAL_STATUS], [EMPLOYEE_START_WORK], [EMPLOYEE_STATUS])
VALUES 
  ('sd', 'sd', 'KASIR', 'Wanita', 'sd', 'sd', 'sd', 'sd', '19890404 18:48:15', 'Tidak Kawin', '20070404 18:48:15', 'Tetap')


INSERT INTO [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID], [EMPLOYEE_NAME], [DEP_ID], [EMPLOYEE_GENDER], [EMPLOYEE_ID_CARD], [EMPLOYEE_ADDRESS], [EMPLOYEE_PHONE], [EMPLOYEE_BIRTH_PLACE], [EMPLOYEE_BIRTH_DATE], [EMPLOYEE_MARITAL_STATUS], [EMPLOYEE_START_WORK], [EMPLOYEE_STATUS])
VALUES 
  ('TANHAP', 'TANHAP', 'KASIR', 'Wanita', '345345', 'riau', '456456', '345345', '20070404 18:48:15', 'Tidak Kawin', '20070404 18:48:15', 'Tetap')


COMMIT

--
-- Data for table M_GUDANG  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[M_GUDANG] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[M_GUDANG] ([GUDANG_ID], [GUDANG_NAME])
VALUES 
  (1, 'MEJA KASIR')


COMMIT


SET IDENTITY_INSERT [dbo].[M_GUDANG] OFF



--
-- Data for table M_ITEM_TYPE  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[M_ITEM_TYPE] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[M_ITEM_TYPE] ([ITEM_TYPE_ID], [ITEM_TYPE_NAME])
VALUES 
  (1, 'BARANG')


INSERT INTO [dbo].[M_ITEM_TYPE] ([ITEM_TYPE_ID], [ITEM_TYPE_NAME])
VALUES 
  (2, 'JASA')


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
  (102, 'Billiard Management Software', 'Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (103, 'Billiard Management Software', 'Pelanggan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (104, 'Billiard Management Software', 'Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (105, 'Billiard Management Software', 'Karyawan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (106, 'Billiard Management Software', 'Bagian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (107, 'Billiard Management Software', 'Meja Billiard', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (201, 'Billiard Management Software', 'Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (202, 'Billiard Management Software', 'Retur Penjualan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (203, 'Billiard Management Software', 'Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (204, 'Billiard Management Software', 'Retur Pembelian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (205, 'Billiard Management Software', 'Penyesuaian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (206, 'Billiard Management Software', 'Billiard', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (301, 'Billiard Management Software', 'Daftar Golongan Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (302, 'Billiard Management Software', 'Daftar Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (303, 'Billiard Management Software', 'Daftar Pelanggan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (304, 'Billiard Management Software', 'Daftar Supplier', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (305, 'Billiard Management Software', 'Daftar Bagian', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (306, 'Billiard Management Software', 'Daftar Karyawan', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (308, 'Billiard Management Software', 'Laporan Total Penjualan Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (309, 'Billiard Management Software', 'Laporan Total Retur Penjualan Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (311, 'Billiard Management Software', 'Laporan Total Pembelian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (312, 'Billiard Management Software', 'Laporan Total Retur Pembelian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (313, 'Billiard Management Software', 'Laporan Total Penyesuaian Per Item', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (401, 'Billiard Management Software', 'Tutup Hari', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (402, 'Billiard Management Software', 'Backup Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (403, 'Billiard Management Software', 'Restore Database', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (404, 'Billiard Management Software', 'Konfigurasi Program', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (405, 'Billiard Management Software', 'Daftar Pengguna', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (406, 'Billiard Management Software', 'Diskon Global', 'OK')


INSERT INTO [dbo].[M_MENU] ([MENU_ID], [SETTING_ID], [MENU_NAME], [MENU_STATUS])
VALUES 
  (407, 'Billiard Management Software', 'Ganti Password', 'OK')


COMMIT


--
-- Data for table M_SETTING  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_SETTING] ([SETTING_ID], [COMPANY_NAME], [COMPANY_ADDRESS], [COMPANY_CITY], [COMPANY_TELP], [AUTO_PRINT_SALES], [AUTO_BACKUP], [BACKUP_DIR], [FACTUR_NO_FORMAT], [FACTUR_NO_LENGTH])
VALUES 
  ('Billiard Management Software', 'NINE BALL BILLIARD', 'Jln Sultan Syarif Qasim', 'Pekanbaru', '(0761) 923053', 0, 1, 'E:\My Project\Inventori', '[xxx]/[meja]', 6)


INSERT INTO [dbo].[M_SETTING] ([SETTING_ID], [COMPANY_NAME], [COMPANY_ADDRESS], [COMPANY_CITY], [COMPANY_TELP], [AUTO_PRINT_SALES], [AUTO_BACKUP], [BACKUP_DIR], [FACTUR_NO_FORMAT], [FACTUR_NO_LENGTH])
VALUES 
  ('Cafe Management Software', 'Kedai Kopi VID', 'Riau Bussiness Center', 'Pekanbaru', '(0761) 555999', 1, 0, '', '[xxx]/[meja]', 5)


COMMIT


--
-- Data for table M_SUPPLIER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_SUPPLIER] ([SUPPLIER_ID], [SUPPLIER_NAME], [SUPPLIER_ADDRESS], [SUPPLIER_PHONE], [SUPPLIER_CONTACT], [SUPPLIER_CONTACT_PHONE])
VALUES 
  ('CASH', 'CASH', '', '', '', '')


COMMIT


--
-- Data for table M_USER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('1', '1', 1)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('2', '2', 1)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('3', '3', 0)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('4', '4', 0)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('5', '5', 0)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('5656', '5656', 1)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('6', '6', 0)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('admin', 'admin', 1)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('rerer', 'rere', 1)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('RYUKI', 'r', 1)


INSERT INTO [dbo].[M_USER] ([USER_NAME], [USER_PASSWORD], [USER_STATUS])
VALUES 
  ('yuyu', 'yuyu', 0)


COMMIT


--
-- Data for table T_BILLIARD_SETTING  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[T_BILLIARD_SETTING] ([SETTING_ID], [BILIARD_ITEM_PRICE], [BILIARD_ITEM_PRICE_VIP], [BILIARD_ITEM_PRICE_MINI], [QUIT_TIMEOUT], [MINIMUM_PLAY], [FULLFILL_PRICE], [REFEREE_BONUS], [BACK_COLOR], [DESK_BACK_COLOR], [DESK_FONT_NAME], [DESK_FONT_SIZE], [DESK_FONT_BOLD], [DESK_FONT_ITALIC], [DESK_FONT_UNDERLINE], [DESK_FONT_COLOR], [DESK_WIDTH], [DESK_HEIGHT], [DESK_BACK_COLOR1], [DESK_FONT_NAME1], [DESK_FONT_SIZE1], [DESK_FONT_BOLD1], [DESK_FONT_ITALIC1], [DESK_FONT_UNDERLINE1], [DESK_FONT_COLOR1], [DESK_WIDTH1], [DESK_HEIGHT1], [DESK_BACK_COLOR2], [DESK_FONT_NAME2], [DESK_FONT_SIZE2], [DESK_FONT_BOLD2], [DESK_FONT_ITALIC2], [DESK_FONT_UNDERLINE2], [DESK_FONT_COLOR2], [DESK_WIDTH2], [DESK_HEIGHT2])
VALUES 
  ('Billiard Management Software', 50000, 60000, 40000, 5, 30, 500, 5000, 0, 16777215, 'Arial Black', 11, 0, 0, 0, 0, 70, 45, 8454143, 'Lucida Sans', 11, 0, 0, 0, 33023, 25, 50, 16744448, 'Verdana', 11, 0, 0, 0, 65280, 25, 80)


COMMIT


--
-- Data for table T_CAFE_SETTING  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[T_CAFE_SETTING] ([SETTING_ID], [EXPORTED_DIR], [DISCOUNT_PASSWORD])
VALUES 
  ('Cafe Management Software', 'C:\Documents and Settings\PERSONAL\Desktop', 'ca')


COMMIT


--
-- Data for table T_DESK  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[T_DESK] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[T_DESK] ([T_DESK_ID], [DESK_ID], [DESK_BOOKING_DATE], [DESK_IN_DATE], [DESK_OUT_DATE], [DESK_CUST_ID], [DESK_LONG_PLAY_MINUTES], [DESK_STATUS], [DESK_TRANSACTION_ID], [DESK_GRAND_TOTAL], [EMPLOYEE_ID])
VALUES 
  (1, '10', '20070424 16:54:08', '20070424 16:54:08', '20070424 16:54:08', 'CASH', 0, 'Paid', 1.28218820489219E17, 25000, '')


COMMIT


SET IDENTITY_INSERT [dbo].[T_DESK] OFF


--
-- Data for table T_MENU_USER  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (101, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (101, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (101, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (102, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (102, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (102, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (103, '1', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (103, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (103, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (104, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (104, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (104, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (105, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (105, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (105, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (106, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (106, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (106, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (107, '1', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (107, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (107, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (201, '1', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (201, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (201, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (202, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (202, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (202, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (203, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (203, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (203, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (204, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (204, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (204, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (205, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (205, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (205, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (206, '1', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (206, 'admin', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (206, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (301, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (301, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (301, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (302, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (302, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (302, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (303, '1', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (303, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (303, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (304, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (304, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (304, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (305, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (305, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (305, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (306, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (306, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (306, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (308, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (308, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (308, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (309, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (309, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (309, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (311, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (311, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (311, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (312, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (312, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (312, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (313, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (313, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (401, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (401, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (401, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (402, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (402, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (402, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (403, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (403, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (403, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (404, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (404, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (404, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (405, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (405, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (405, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (406, '1', 'Billiard Management Software', 0)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (406, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (406, 'RYUKI', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (407, '1', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (407, 'admin', 'Billiard Management Software', 1)


INSERT INTO [dbo].[T_MENU_USER] ([MENU_ID], [USER_NAME], [SETTING_ID], [HAS_ACCESS])
VALUES 
  (407, 'RYUKI', 'Billiard Management Software', 1)


COMMIT


--
-- Data for table T_STOK_CARD  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[T_STOK_CARD] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[T_STOK_CARD] ([STOK_CARD_ID], [ITEM_ID], [STOK_CARD_DATE], [TRANSACTION_ID], [STOK_CARD_STATUS], [STOK_CARD_QUANTITY], [STOK_CARD_SALDO], [STOK_CARD_PIC])
VALUES 
  (1, 'Rental Meja 10', '20070424 16:54:08', 1.28218820278594E17, 0, 1, 0, 'lbl_UserName')


INSERT INTO [dbo].[T_STOK_CARD] ([STOK_CARD_ID], [ITEM_ID], [STOK_CARD_DATE], [TRANSACTION_ID], [STOK_CARD_STATUS], [STOK_CARD_QUANTITY], [STOK_CARD_SALDO], [STOK_CARD_PIC])
VALUES 
  (2, 'Ayam Goreng (L)', '20070424 16:54:08', 1.28218820278594E17, 0, 1, 0, 'lbl_UserName')


COMMIT


SET IDENTITY_INSERT [dbo].[T_STOK_CARD] OFF


--
-- Data for table T_TRANSACTION  (LIMIT 0,500)
--

BEGIN TRANSACTION


INSERT INTO [dbo].[T_TRANSACTION] ([TRANSACTION_ID], [TRANSACTION_FACTUR], [TRANSACTION_BY], [TRANSACTION_DATE], [TRANSACTION_SUB_TOTAL], [TRANSACTION_DISC], [TRANSACTION_PPN], [TRANSACTION_GRAND_TOTAL], [TRANSACTION_PAID], [TRANSACTION_SISA], [TRANSACTION_STATUS], [TRANSACTION_DESK], [EMPLOYEE_ID])
VALUES 
  (1.28218820278594E17, '000001/10', 'CASH', '20070424 16:54:01', 65000, 0, 0, 65000, 65000, 0, 'Sales', '10', 'TANHAP')


COMMIT


--
-- Data for table T_TRANSACTION_DETAIL  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[T_TRANSACTION_DETAIL] ON


BEGIN TRANSACTION


INSERT INTO [dbo].[T_TRANSACTION_DETAIL] ([TRANSACTION_DETAIL_ID], [TRANSACTION_ID], [ITEM_ID], [QUANTITY], [PRICE], [JUMLAH], [DISC], [PPN], [TOTAL])
VALUES 
  (2, 1.28218820278594E17, 'Rental Meja 10', 0.5, 50000, 0, 0, 0, 25000)


INSERT INTO [dbo].[T_TRANSACTION_DETAIL] ([TRANSACTION_DETAIL_ID], [TRANSACTION_ID], [ITEM_ID], [QUANTITY], [PRICE], [JUMLAH], [DISC], [PPN], [TOTAL])
VALUES 
  (3, 1.28218820278594E17, 'Ayam Goreng (L)', 1, 40000, 0, 0, 0, 40000)


COMMIT


SET IDENTITY_INSERT [dbo].[T_TRANSACTION_DETAIL] OFF


--
-- Definition for indices : 
--

ALTER TABLE [dbo].[ITEM_GUDANG_STOK]
ADD CONSTRAINT [PK_ITEM_GUDANG_STOK_1] 
PRIMARY KEY CLUSTERED ([ITEM_ID])
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

