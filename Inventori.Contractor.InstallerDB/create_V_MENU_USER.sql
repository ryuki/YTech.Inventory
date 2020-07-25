--
-- Definition for view V_MENU_USER :
--

CREATE VIEW dbo.V_MENU_USER
AS
SELECT DISTINCT
                      dbo.M_MENU.MENU_ID, ISNULL(dbo.M_MENU.MENU_NAME, '') AS MENU_NAME, ISNULL(dbo.T_MENU_USER.USER_NAME, '') AS USER_NAME,
                      ISNULL(dbo.T_MENU_USER.HAS_ACCESS, 0) AS HAS_ACCESS
FROM         dbo.M_MENU LEFT OUTER JOIN
                      dbo.T_MENU_USER ON dbo.M_MENU.MENU_ID = dbo.T_MENU_USER.MENU_ID