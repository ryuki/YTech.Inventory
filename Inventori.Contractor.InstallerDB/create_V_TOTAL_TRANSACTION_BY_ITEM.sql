--
-- Definition for view V_TOTAL_TRANSACTION_BY_ITEM :
--

CREATE VIEW dbo.V_TOTAL_TRANSACTION_BY_ITEM
AS
SELECT     dbo.M_GROUP.GROUP_NAME, dbo.M_ITEM.ITEM_NAME, SUM(dbo.T_TRANSACTION_DETAIL.TOTAL) AS TOTAL,
                      dbo.T_TRANSACTION.TRANSACTION_STATUS
FROM         dbo.M_GROUP INNER JOIN
                      dbo.M_ITEM ON dbo.M_GROUP.GROUP_ID = dbo.M_ITEM.GROUP_ID INNER JOIN
                      dbo.T_TRANSACTION_DETAIL ON dbo.M_ITEM.ITEM_ID = dbo.T_TRANSACTION_DETAIL.ITEM_ID INNER JOIN
                      dbo.T_TRANSACTION ON dbo.T_TRANSACTION_DETAIL.TRANSACTION_ID = dbo.T_TRANSACTION.TRANSACTION_ID
GROUP BY dbo.M_GROUP.GROUP_NAME, dbo.M_ITEM.ITEM_NAME, dbo.T_TRANSACTION.TRANSACTION_STATUS