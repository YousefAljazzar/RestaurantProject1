-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: restaurantdb
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Temporary view structure for view `csvview`
--

DROP TABLE IF EXISTS `csvview`;
/*!50001 DROP VIEW IF EXISTS `csvview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `csvview` AS SELECT 
 1 AS `RestaurantName`,
 1 AS `NumberOfOrderedCustomer`,
 1 AS `ProfitInUsd`,
 1 AS `ProfitInNis`,
 1 AS `TheBestSellingMeal`,
 1 AS `MostPurchasedCustomer`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `csvview`
--

/*!50001 DROP VIEW IF EXISTS `csvview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `csvview` AS select `r`.`Name` AS `RestaurantName`,`calc`.`soldQty` AS `NumberOfOrderedCustomer`,`calc`.`priceInUsd` AS `ProfitInUsd`,`calc`.`priceInNis` AS `ProfitInNis`,`rm`.`MealName` AS `TheBestSellingMeal`,concat(`c`.`FirstName`,' ',`c`.`LastName`) AS `MostPurchasedCustomer` from (((((`restaurant` `r` left join (select `a`.`RestaurantId` AS `RestaurantId`,`a`.`total` AS `total`,`a`.`custmerId` AS `custmerId` from (select `customerorder`.`custmerId` AS `custmerId`,sum(`customerorder`.`CustmerOrderQuntity`) AS `total`,`rm`.`RestaurantId` AS `RestaurantId` from (`customerorder` left join `restaurantmenu` `rm` on((`customerorder`.`mealId` = `rm`.`Id`))) group by `customerorder`.`custmerId`,`rm`.`RestaurantId` order by sum(`customerorder`.`CustmerOrderQuntity`) desc) `a` group by `a`.`RestaurantId`) `topcust` on((`topcust`.`RestaurantId` = `r`.`Id`))) left join (select sum(`co`.`CustmerOrderQuntity`) AS `soldQty`,(sum(`co`.`CustmerOrderQuntity`) * `rm`.`PriceInUsd`) AS `priceInUsd`,(sum(`co`.`CustmerOrderQuntity`) * `rm`.`PriceInNis`) AS `priceInNis`,`rm`.`RestaurantId` AS `RestaurantId` from (`customerorder` `co` left join `restaurantmenu` `rm` on((`rm`.`Id` = `co`.`mealId`))) group by `rm`.`RestaurantId`) `calc` on((`calc`.`RestaurantId` = `r`.`Id`))) left join (select `b`.`MealId` AS `MealId`,`b`.`sumOrder` AS `sumOrder`,`b`.`RestaurantId` AS `RestaurantId` from (select `customerorder`.`mealId` AS `MealId`,sum(`customerorder`.`CustmerOrderQuntity`) AS `sumOrder`,`rm1`.`RestaurantId` AS `RestaurantId` from (`customerorder` left join `restaurantmenu` `rm1` on((`rm1`.`Id` = `customerorder`.`mealId`))) group by `customerorder`.`mealId`,`rm1`.`RestaurantId`) `b` group by `b`.`RestaurantId`) `topmeal` on((`topmeal`.`RestaurantId` = `r`.`Id`))) left join `customer` `c` on((`c`.`Id` = `topcust`.`custmerId`))) left join `restaurantmenu` `rm` on((`rm`.`Id` = `topmeal`.`MealId`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-16  2:43:09
