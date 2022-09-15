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
-- Table structure for table `restaurantmenu`
--

DROP TABLE IF EXISTS `restaurantmenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `restaurantmenu` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MealName` varchar(255) NOT NULL,
  `PriceInNis` decimal(10,2) NOT NULL,
  `PriceInUsd` decimal(10,2) NOT NULL,
  `Quantity` int NOT NULL,
  `CreatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Archived` tinyint NOT NULL DEFAULT '0',
  `RestaurantId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `restarentId_menu_idx` (`RestaurantId`),
  CONSTRAINT `restarentId_menu` FOREIGN KEY (`RestaurantId`) REFERENCES `restaurant` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `restaurantmenu`
--

LOCK TABLES `restaurantmenu` WRITE;
/*!40000 ALTER TABLE `restaurantmenu` DISABLE KEYS */;
INSERT INTO `restaurantmenu` VALUES (2,'Kabab',10.00,2.86,20,'2022-09-14 10:28:29','2022-09-14 15:33:23',0,1),(3,'Barger',10.00,2.86,20,'2022-09-14 10:58:45','2022-09-15 22:50:00',0,1),(4,'SeaFoad',50.00,14.29,10,'2022-09-14 11:03:40','2022-09-14 11:03:40',0,2),(5,'asd',10.00,2.86,10,'2022-09-14 11:05:59','2022-09-14 11:05:59',0,1),(6,'Kabab',10.00,2.86,20,'2022-09-14 11:07:07','2022-09-15 22:50:00',0,2),(7,'Sharmwa',30.00,8.50,20,'2022-09-14 20:44:21','2022-09-14 20:44:21',0,3);
/*!40000 ALTER TABLE `restaurantmenu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-16  2:43:09
