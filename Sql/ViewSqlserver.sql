USE [restaurantdb]
GO

/****** Object:  View [dbo].[alldata]    Script Date: 9/23/2022 3:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[alldata] as(select Top 2  restaurant.Name as RestaurantName,count(co.MealID) as NumberOfOrderedCustomer, sum(co.CustmerOrderQuntity*rm.PriceInUsd) as ProfitInUsd, sum(co.CustmerOrderQuntity*rm.PriceInNis) as ProfitInNis,
rm.MealName
from custmerorder co inner join customer on customer.id = co.id join restaurantmenu rm 
on co.MealId  = rm.id
join restaurant restaurant on restaurant.id = rm.RestaurantID
group by restaurant.Name ,MealName

)
GO

