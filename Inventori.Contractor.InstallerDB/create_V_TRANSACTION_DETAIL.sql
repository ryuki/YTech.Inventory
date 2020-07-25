--
-- Definition for view V_TRANSACTION_DETAIL :
--

CREATE VIEW dbo.V_TRANSACTION_DETAIL
AS
SELECT     dbo.T_TRANSACTION_DETAIL.*, dbo.M_ITEM.ITEM_NAME
FROM         dbo.T_TRANSACTION_DETAIL LEFT OUTER JOIN
                      dbo.M_ITEM ON dbo.T_TRANSACTION_DETAIL.ITEM_ID = dbo.M_ITEM.ITEM_ID