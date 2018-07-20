

--仅仅用于搜索显示给用户的列表页面
--注意索引

CREATE PROC SP_SEARCH_CUSTOMER_FOR_USER(
	@StartDate	Datetime = NULL,
	@EndDate	Datetime = NULL,
	@Area		nvarchar(60) = N'',
	@Age_Max	Int = 0,
	@Age_Min	Int = 0
)
AS
BEGIN
	
	SELECT  
	   Id
       ,Name
      ,Area
      ,Age
      ,IdCard
      --,[Interest]
      --,[DebitAmount]
      --,[SesameScore]
      --,[CreditRating]
      
	  ,ApplicationDate
      
	  --,[Tel]
      --,[WeChat]
      --,[QQ]
      
	  --,[AppEquipment]
      --,[Source]
      ,TransTimes
      ,RecordCharge
      --,[IsActive]
      --,[CreationTime]
      --,[CreatorUserId]
      --,CustomerNo
      --,[IsComplete]
      ,BuyUserIds

  FROM CustomerInfo
  WHERE
		(@StartDate IS NULL OR ApplicationDate >= @StartDate) AND
		(@EndDate IS NULL OR ApplicationDate <= @EndDate) AND
		(@Area = N'' OR Area = @Area + '%') AND
		(@Age_Max = 0  OR Age <= @Age_Max) AND
		(@Age_Min = 0 OR Age >= @Age_Min)
END