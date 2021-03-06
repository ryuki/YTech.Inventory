--
-- Definition for view V_ITEM_DETAIL : 
--

CREATE VIEW dbo.V_ITEM_DETAIL
AS
SELECT     dbo.M_ITEM.ITEM_ID, dbo.M_ITEM.ITEM_TYPE_ID, dbo.M_ITEM.GROUP_ID, dbo.M_ITEM.ITEM_NAME, dbo.M_ITEM.ITEM_SATUAN, 
                      dbo.M_ITEM.ITEM_DESC, dbo.M_ITEM.ITEM_COMMISION, dbo.M_ITEM.DEFAULT_GUDANG_ID, dbo.M_ITEM.ITEM_PRICE_MAX_VIP, 
                      dbo.M_ITEM.ITEM_PRICE_MIN_VIP, dbo.M_ITEM.ITEM_PRICE_MAX, dbo.M_ITEM.ITEM_PRICE_MIN, dbo.M_ITEM.ITEM_PRICE_PURCHASE, 
                      dbo.M_ITEM.MODIFIED_BY, dbo.M_ITEM.MODIFIED_DATE, ISNULL(dbo.M_GROUP.GROUP_NAME, '') AS GROUP_NAME, 
                      ISNULL(dbo.M_ITEM_TYPE.ITEM_TYPE_NAME, '') AS ITEM_TYPE_NAME, ISNULL(dbo.M_GUDANG.GUDANG_NAME, '') AS GUDANG_NAME, 
                      ISNULL(dbo.ITEM_GUDANG_STOK.ITEM_STOK, 0) AS ITEM_STOK, ISNULL(dbo.ITEM_GUDANG_STOK.ITEM_MIN_STOK, 0) AS ITEM_MIN_STOK, 
                      ISNULL(dbo.ITEM_GUDANG_STOK.ITEM_MAX_STOK, 0) AS ITEM_MAX_STOK, ISNULL(dbo.ITEM_GUDANG_STOK.GUDANG_ID, 0) AS GUDANG_ID
FROM         dbo.ITEM_GUDANG_STOK INNER JOIN
                      dbo.M_GUDANG ON dbo.ITEM_GUDANG_STOK.GUDANG_ID = dbo.M_GUDANG.GUDANG_ID RIGHT OUTER JOIN
                      dbo.M_ITEM ON dbo.ITEM_GUDANG_STOK.ITEM_ID = dbo.M_ITEM.ITEM_ID LEFT OUTER JOIN
                      dbo.M_ITEM_TYPE ON dbo.M_ITEM.ITEM_TYPE_ID = dbo.M_ITEM_TYPE.ITEM_TYPE_ID LEFT OUTER JOIN
                      dbo.M_GROUP ON dbo.M_ITEM.GROUP_ID = dbo.M_GROUP.GROUP_ID