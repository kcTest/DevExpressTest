USE DevTest
GO
/****** Script for SelectTopNRows command from SSMS  ******/

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM [DevTest].[dbo].[t合约业务] ORDER BY fID DESC

BEGIN TRAN
DELETE  FROM [DevTest].[dbo].[t合约业务] WHERE 名称='ef1'
ROLLBACK

SELECT * FROM [DevTest].[dbo].[t费用收入](NOLOCK)  ORDER BY fID DESC


/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [业务ID]
  ,[类别]
  ,[项目名称]
  ,[金额]
  ,[期数]
  ,[状态]
FROM [DevTest].[dbo].[v费用收入]

SELECT  业务ID ,SUM(金额)  FROM dbo.v费用收入 GROUP BY 业务ID
SELECT  业务ID ,类别,SUM(金额)  FROM dbo.v费用收入 GROUP BY 业务ID,类别


SELECT  业务ID,COUNT(业务ID) 次数  FROM dbo.v费用收入 GROUP BY 业务ID
SELECT 类别, 业务ID,COUNT(业务ID) 次数,SUM(金额) 消费 FROM dbo.v费用收入 GROUP BY 业务ID, 类别  ORDER BY 业务ID DESC

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT DISTINCT 省中文  FROM [DevTest].[dbo].[t城市列表] WHERE 中文=所属上级市中文 ORDER BY 省中文 DESC

SELECT [所属上级市中文] FROM [DevTest].[dbo].[t城市列表] WHERE 省中文='重庆' AND 中文=所属上级市中文