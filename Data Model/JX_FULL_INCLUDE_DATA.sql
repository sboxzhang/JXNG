CREATE DATABASE  IF NOT EXISTS `demodb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `demodb`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: demodb
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `BuAddress`
--

DROP TABLE IF EXISTS `BuAddress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuAddress` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AddressName` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UQ_address_id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='地址表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuAddress`
--

LOCK TABLES `BuAddress` WRITE;
/*!40000 ALTER TABLE `BuAddress` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuAddress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuBigStationInfo`
--

DROP TABLE IF EXISTS `BuBigStationInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuBigStationInfo` (
  `BigStationId` int(11) NOT NULL AUTO_INCREMENT COMMENT '总站ID',
  `BigStationName` varchar(150) NOT NULL COMMENT '总站名称',
  `BigStationProvince` int(11) NOT NULL COMMENT '所在省份',
  `BigStationCity` int(11) NOT NULL COMMENT '所在城市',
  `BigSstationAddress` int(11) NOT NULL COMMENT '所在地址',
  PRIMARY KEY (`BigStationId`),
  UNIQUE KEY `UQ_bigstationinfo_bstationid` (`BigStationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='总站信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuBigStationInfo`
--

LOCK TABLES `BuBigStationInfo` WRITE;
/*!40000 ALTER TABLE `BuBigStationInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuBigStationInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuCarInfo`
--

DROP TABLE IF EXISTS `BuCarInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuCarInfo` (
  `CarNumber` varchar(50) NOT NULL COMMENT '车牌号',
  `CarName` varchar(50) NOT NULL COMMENT '车辆名称',
  `CarKind` varchar(50) DEFAULT NULL COMMENT '车辆类型',
  `CarRemark` longtext COMMENT '车辆备注',
  PRIMARY KEY (`CarNumber`),
  UNIQUE KEY `UQ_Carinfo_carnumber` (`CarNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='车辆信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuCarInfo`
--

LOCK TABLES `BuCarInfo` WRITE;
/*!40000 ALTER TABLE `BuCarInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuCarInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuCarRepair`
--

DROP TABLE IF EXISTS `BuCarRepair`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuCarRepair` (
  `RepairId` int(11) NOT NULL COMMENT '检修ID',
  `RepairDate` date NOT NULL COMMENT '检修日期',
  `CarNumber` varchar(50) NOT NULL COMMENT '检修车牌号',
  `DutyOfficer` varchar(50) NOT NULL COMMENT '检修负责人',
  `RepairComment` longtext NOT NULL COMMENT '检修说明',
  PRIMARY KEY (`RepairId`),
  UNIQUE KEY `UQ_carrepair_repairid` (`RepairId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='车辆检修记录表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuCarRepair`
--

LOCK TABLES `BuCarRepair` WRITE;
/*!40000 ALTER TABLE `BuCarRepair` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuCarRepair` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuCityInfo`
--

DROP TABLE IF EXISTS `BuCityInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuCityInfo` (
  `CityCode` varchar(50) NOT NULL COMMENT '城市ID',
  `CityName` varchar(50) NOT NULL COMMENT '城市名称',
  `ProvinceId` int(11) NOT NULL COMMENT '所属省份ID',
  PRIMARY KEY (`CityCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='城市信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuCityInfo`
--

LOCK TABLES `BuCityInfo` WRITE;
/*!40000 ALTER TABLE `BuCityInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuCityInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuGPSInfo`
--

DROP TABLE IF EXISTS `BuGPSInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuGPSInfo` (
  `GPSId` varchar(50) NOT NULL COMMENT 'GPS同步ID',
  `SynchronizationType` varchar(50) NOT NULL COMMENT '同步类型',
  `SynchronizationTime` datetime NOT NULL COMMENT '同步时间',
  `SynchronizationStatus` varchar(50) NOT NULL COMMENT '同步状态',
  `Longitude` varchar(50) NOT NULL COMMENT '经度',
  `Latitude` varchar(50) NOT NULL COMMENT '纬度',
  `CarId` int(11) NOT NULL,
  PRIMARY KEY (`GPSId`),
  UNIQUE KEY `UQ_GPSinfo_gpsid` (`GPSId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='GPS同步信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuGPSInfo`
--

LOCK TABLES `BuGPSInfo` WRITE;
/*!40000 ALTER TABLE `BuGPSInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuGPSInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuGPSLog`
--

DROP TABLE IF EXISTS `BuGPSLog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuGPSLog` (
  `GPSLogId` int(11) NOT NULL AUTO_INCREMENT COMMENT 'logoid',
  `SynchronizationStatus` varchar(50) NOT NULL,
  `SynchronizationDate` datetime NOT NULL COMMENT '同步日期',
  `SynchronizationInfo` varchar(200) NOT NULL COMMENT '同步信息',
  PRIMARY KEY (`GPSLogId`),
  UNIQUE KEY `UQ_GPSlogo_gpslogoid` (`GPSLogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='GPS同步日志表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuGPSLog`
--

LOCK TABLES `BuGPSLog` WRITE;
/*!40000 ALTER TABLE `BuGPSLog` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuGPSLog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuGastankInfo`
--

DROP TABLE IF EXISTS `BuGastankInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuGastankInfo` (
  `TankNumber` varchar(100) NOT NULL COMMENT '气罐编号',
  `TankKind` varchar(100) NOT NULL COMMENT '气罐类型',
  `TankVolume` varchar(100) NOT NULL COMMENT '气罐容量',
  `Tank1` varchar(100) DEFAULT NULL COMMENT '预留字段',
  `Tank2` varchar(100) DEFAULT NULL COMMENT '预留字段',
  `Tank3` varchar(100) DEFAULT NULL COMMENT '预留字段',
  PRIMARY KEY (`TankNumber`),
  UNIQUE KEY `UQ_gastank_tanknumber` (`TankNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='气罐信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuGastankInfo`
--

LOCK TABLES `BuGastankInfo` WRITE;
/*!40000 ALTER TABLE `BuGastankInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuGastankInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuGastankRepair`
--

DROP TABLE IF EXISTS `BuGastankRepair`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuGastankRepair` (
  `GasRepairId` int(11) NOT NULL AUTO_INCREMENT COMMENT '检修信息ID（表）',
  `GasRepairDate` date NOT NULL COMMENT '检修日期',
  `TankNumber` varchar(50) NOT NULL COMMENT '气罐编号',
  `DutyOfficer` varchar(50) NOT NULL COMMENT '检修责任人',
  `Remark` longtext COMMENT '备注',
  PRIMARY KEY (`GasRepairId`),
  UNIQUE KEY `UQ_gastankrepair_gasrepairid` (`GasRepairId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='气罐检修记录表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuGastankRepair`
--

LOCK TABLES `BuGastankRepair` WRITE;
/*!40000 ALTER TABLE `BuGastankRepair` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuGastankRepair` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuKindInfo`
--

DROP TABLE IF EXISTS `BuKindInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuKindInfo` (
  `KindId` int(11) NOT NULL AUTO_INCREMENT COMMENT '类别ID',
  `KindName` varchar(50) NOT NULL COMMENT '类别名称',
  PRIMARY KEY (`KindId`),
  UNIQUE KEY `UQ_kindinfo_kindid` (`KindId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='类别信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuKindInfo`
--

LOCK TABLES `BuKindInfo` WRITE;
/*!40000 ALTER TABLE `BuKindInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuKindInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuPost`
--

DROP TABLE IF EXISTS `BuPost`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuPost` (
  `PostId` int(11) NOT NULL AUTO_INCREMENT COMMENT '刚才ID',
  `PostName` varchar(50) NOT NULL COMMENT '岗位名称',
  `UserId` int(11) NOT NULL COMMENT '审批人ID',
  `UserName` varchar(50) NOT NULL COMMENT '用户名称（数据冗余，方便后期检索）',
  PRIMARY KEY (`PostId`),
  UNIQUE KEY `UQ_post_postid` (`PostId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='审批岗位表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuPost`
--

LOCK TABLES `BuPost` WRITE;
/*!40000 ALTER TABLE `BuPost` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuPost` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuProvinceInfo`
--

DROP TABLE IF EXISTS `BuProvinceInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuProvinceInfo` (
  `ProvinceCode` varchar(50) NOT NULL COMMENT '省份代码',
  `ProvinceName` varchar(50) NOT NULL COMMENT '身份名称',
  PRIMARY KEY (`ProvinceCode`),
  UNIQUE KEY `UQ_provinceinfo_provinceid` (`ProvinceCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='省份信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuProvinceInfo`
--

LOCK TABLES `BuProvinceInfo` WRITE;
/*!40000 ALTER TABLE `BuProvinceInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuProvinceInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuRepairing`
--

DROP TABLE IF EXISTS `BuRepairing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuRepairing` (
  `RepairingId` int(11) NOT NULL AUTO_INCREMENT,
  `RepairingName` varchar(50) NOT NULL,
  `RepairingDate` varchar(50) NOT NULL,
  PRIMARY KEY (`RepairingId`),
  UNIQUE KEY `UQ_Repairing_Repairingid` (`RepairingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuRepairing`
--

LOCK TABLES `BuRepairing` WRITE;
/*!40000 ALTER TABLE `BuRepairing` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuRepairing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuSchedule`
--

DROP TABLE IF EXISTS `BuSchedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuSchedule` (
  `ScheduleId` int(11) NOT NULL AUTO_INCREMENT COMMENT '调度ID',
  `ScheduleName` varchar(50) NOT NULL COMMENT '调度名称',
  `CreateMan` varchar(50) NOT NULL COMMENT '调度员',
  `CreateDate` datetime NOT NULL COMMENT '调度日期',
  `UpdateMan` varchar(50) NOT NULL COMMENT '修改人',
  `UpdateDate` varchar(50) NOT NULL COMMENT '修改时间',
  `ScheduleStatus` varchar(5) NOT NULL COMMENT '调度状态',
  `ScheduleKind` int(11) NOT NULL COMMENT '调度类型',
  `StationId` varchar(50) NOT NULL COMMENT '站点',
  `StationBossId` varchar(50) NOT NULL COMMENT '站长',
  `ExecuteDate` datetime NOT NULL COMMENT '执行日期',
  `ApplyDate` datetime NOT NULL COMMENT '申请日期',
  `StartAddress` varchar(50) NOT NULL COMMENT '发车地址',
  `BigStationId` int(11) NOT NULL COMMENT '总站',
  `TakeTime` datetime NOT NULL COMMENT '路途花费时间',
  `AddTime` datetime NOT NULL COMMENT '冗余时间',
  `TargetAddress` varchar(50) NOT NULL COMMENT '目标地点',
  `NeedTime` datetime NOT NULL COMMENT '用气时间',
  PRIMARY KEY (`ScheduleId`),
  UNIQUE KEY `UQ_Schedule_Scheduleid` (`ScheduleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='调度排班表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuSchedule`
--

LOCK TABLES `BuSchedule` WRITE;
/*!40000 ALTER TABLE `BuSchedule` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuSchedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuScheduleApply`
--

DROP TABLE IF EXISTS `BuScheduleApply`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuScheduleApply` (
  `ApplyId` varchar(50) NOT NULL COMMENT '审批ID',
  `ApplyMan` varchar(50) NOT NULL COMMENT '审批人对应post表中的userid',
  `ApplyDate` datetime NOT NULL COMMENT '审批日期',
  PRIMARY KEY (`ApplyId`),
  UNIQUE KEY `UQ_Scheduleapply_applyid` (`ApplyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='调度审批表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuScheduleApply`
--

LOCK TABLES `BuScheduleApply` WRITE;
/*!40000 ALTER TABLE `BuScheduleApply` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuScheduleApply` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuStationInfo`
--

DROP TABLE IF EXISTS `BuStationInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuStationInfo` (
  `StationId` int(11) NOT NULL AUTO_INCREMENT COMMENT '站点ID',
  `StationName` varchar(50) NOT NULL COMMENT '站点名称',
  `StationBoss` varchar(50) NOT NULL COMMENT '站长（扛把子）',
  `ProvinceId` int(11) NOT NULL COMMENT '省份id',
  `CityId` int(11) NOT NULL COMMENT '城市id',
  `Address` varchar(100) NOT NULL COMMENT '地址',
  PRIMARY KEY (`StationId`),
  UNIQUE KEY `UQ_stationinfo_stationid` (`StationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='站点信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuStationInfo`
--

LOCK TABLES `BuStationInfo` WRITE;
/*!40000 ALTER TABLE `BuStationInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuStationInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuTypeInfo`
--

DROP TABLE IF EXISTS `BuTypeInfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuTypeInfo` (
  `TypeId` int(11) NOT NULL AUTO_INCREMENT COMMENT '类型ID',
  `TypeName` varchar(50) NOT NULL COMMENT '类型名称',
  `KindId` int(11) NOT NULL COMMENT '类别ID',
  PRIMARY KEY (`TypeId`),
  UNIQUE KEY `UQ_typeinfo_typeid` (`TypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='类型信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuTypeInfo`
--

LOCK TABLES `BuTypeInfo` WRITE;
/*!40000 ALTER TABLE `BuTypeInfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuTypeInfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuWFProcess`
--

DROP TABLE IF EXISTS `BuWFProcess`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuWFProcess` (
  `ProcessId` int(11) NOT NULL AUTO_INCREMENT COMMENT '节点ID',
  `processName` varchar(50) NOT NULL COMMENT '节点名称',
  PRIMARY KEY (`ProcessId`),
  UNIQUE KEY `UQ_WFProcess_Processid` (`ProcessId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='节点信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuWFProcess`
--

LOCK TABLES `BuWFProcess` WRITE;
/*!40000 ALTER TABLE `BuWFProcess` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuWFProcess` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuWFRelationship`
--

DROP TABLE IF EXISTS `BuWFRelationship`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuWFRelationship` (
  `RelationshipId` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `WorkflowGUID` varchar(50) NOT NULL COMMENT '流程GUID',
  `LastProcessId` int(11) NOT NULL COMMENT '上一步',
  `CurProcessId` int(11) NOT NULL COMMENT '当前步骤',
  `NextProcessId` int(11) NOT NULL COMMENT '下一步',
  `ApprovePostId` int(11) NOT NULL COMMENT '审批职位ID',
  `ApprovePostName` varchar(50) NOT NULL COMMENT '审批职位(冗余)（对迎当前节点）',
  `Enable` tinyint(1) NOT NULL COMMENT '是否启用',
  PRIMARY KEY (`RelationshipId`),
  UNIQUE KEY `UQ_WFrelationship_relationshipid` (`RelationshipId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='流程节点关系表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuWFRelationship`
--

LOCK TABLES `BuWFRelationship` WRITE;
/*!40000 ALTER TABLE `BuWFRelationship` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuWFRelationship` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuWFRelationshipLog`
--

DROP TABLE IF EXISTS `BuWFRelationshipLog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuWFRelationshipLog` (
  `LogId` int(11) NOT NULL AUTO_INCREMENT COMMENT '日志ID',
  `RelationshipId` int(11) NOT NULL COMMENT '审批关系ID',
  `Status` int(11) NOT NULL COMMENT '流程状态',
  PRIMARY KEY (`LogId`),
  UNIQUE KEY `UQ_WFrelationshiplogo_logoid` (`LogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='流程审批日志表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuWFRelationshipLog`
--

LOCK TABLES `BuWFRelationshipLog` WRITE;
/*!40000 ALTER TABLE `BuWFRelationshipLog` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuWFRelationshipLog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `BuWorkFlow`
--

DROP TABLE IF EXISTS `BuWorkFlow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `BuWorkFlow` (
  `WorkflowGUID` varchar(50) NOT NULL COMMENT '流程GUID',
  `WorkflowName` varchar(50) NOT NULL COMMENT '流程名称',
  PRIMARY KEY (`WorkflowGUID`),
  UNIQUE KEY `UQ_Workflow_Workflowguid` (`WorkflowGUID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='流程表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `BuWorkFlow`
--

LOCK TABLES `BuWorkFlow` WRITE;
/*!40000 ALTER TABLE `BuWorkFlow` DISABLE KEYS */;
/*!40000 ALTER TABLE `BuWorkFlow` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ayjz_xxts`
--

DROP TABLE IF EXISTS `ayjz_xxts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ayjz_xxts` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `FSR` varchar(20) DEFAULT NULL COMMENT '发送人',
  `FSSJ` datetime DEFAULT NULL COMMENT '发送时间',
  `FSNR` varchar(200) DEFAULT NULL COMMENT '发送内容',
  `JSR` varchar(20) DEFAULT NULL COMMENT '接收人',
  `QLSJ` datetime DEFAULT NULL COMMENT '处理时间',
  `CLJG` varchar(20) DEFAULT NULL COMMENT '处理结果(0:未解决，1:已解决)',
  `BJ` varchar(2) DEFAULT '0' COMMENT '标志(0:未读，1:已读)',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='站内信';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ayjz_xxts`
--

LOCK TABLES `ayjz_xxts` WRITE;
/*!40000 ALTER TABLE `ayjz_xxts` DISABLE KEYS */;
INSERT INTO `ayjz_xxts` VALUES (1,'zengdl','2014-05-07 17:18:47','qaqaqaq','zengdl',NULL,NULL,'0'),(2,'zengdl','2014-05-07 17:19:39','1212','zengdl',NULL,NULL,'0'),(3,'zengdl','2014-05-07 17:21:24','12121','zhangyl',NULL,NULL,'0'),(4,'zengdl','2014-05-07 17:21:33','','zhangyl',NULL,NULL,'0');
/*!40000 ALTER TABLE `ayjz_xxts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deptinfo`
--

DROP TABLE IF EXISTS `deptinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `deptinfo` (
  `DEPTID` varchar(10) CHARACTER SET utf8 NOT NULL,
  `DEPTNAME` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `PARENTID` varchar(10) CHARACTER SET utf8 DEFAULT '0',
  `REMARK` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `DEPTTYPE` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `ISCLBM` char(1) DEFAULT NULL,
  PRIMARY KEY (`DEPTID`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deptinfo`
--

LOCK TABLES `deptinfo` WRITE;
/*!40000 ALTER TABLE `deptinfo` DISABLE KEYS */;
INSERT INTO `deptinfo` VALUES ('LS','临时','0','','',NULL);
/*!40000 ALTER TABLE `deptinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dictinfo`
--

DROP TABLE IF EXISTS `dictinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dictinfo` (
  `CODE` varchar(20) CHARACTER SET utf8 NOT NULL,
  `NAME` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `TYPE` varchar(10) CHARACTER SET utf8 NOT NULL,
  `REMARK` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `SORT` int(11) DEFAULT NULL,
  `ISENABLE` char(1) DEFAULT 'Y',
  `JC` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dictinfo`
--

LOCK TABLES `dictinfo` WRITE;
/*!40000 ALTER TABLE `dictinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `dictinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dicttypeinfo`
--

DROP TABLE IF EXISTS `dicttypeinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dicttypeinfo` (
  `CODE` varchar(10) CHARACTER SET utf8 NOT NULL,
  `NAME` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dicttypeinfo`
--

LOCK TABLES `dicttypeinfo` WRITE;
/*!40000 ALTER TABLE `dicttypeinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `dicttypeinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moudleinfo`
--

DROP TABLE IF EXISTS `moudleinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moudleinfo` (
  `MOUDLEID` int(11) NOT NULL AUTO_INCREMENT,
  `MOUDLENAME` varchar(20) DEFAULT NULL,
  `URL` varchar(100) DEFAULT NULL,
  `PARENTID` int(11) DEFAULT '0',
  `IMG` varchar(50) DEFAULT NULL,
  `ISENABLE` char(1) DEFAULT NULL,
  `ISROOT` char(1) DEFAULT NULL,
  `SORT` varchar(5) DEFAULT '0',
  `YWLX` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`MOUDLEID`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moudleinfo`
--

LOCK TABLES `moudleinfo` WRITE;
/*!40000 ALTER TABLE `moudleinfo` DISABLE KEYS */;
INSERT INTO `moudleinfo` VALUES (1,'系统字典维护','admin/DictManager/Default.aspx',9,'images/icon/3.png','Y','N','Z7',NULL),(2,'岗位管理','admin/Postmanager/Default.aspx',9,'images/icon/13.png','Y','N','Z3',NULL),(3,'部门管理','admin/DeptManager/Default.aspx',9,'images/icon/1.png','Y','N','Z2',NULL),(4,'模块管理','admin/MoudleManager/Default.aspx',9,'images/icon/2.png','Y','N','Z3',NULL),(5,'模块功能管理','admin/PowerManager/Default.aspx',9,'images/icon/3.png','Y','N','Z4',NULL),(6,'角色管理','admin/RoleManager/Default.aspx',9,'images/icon/4.png','Y','N','Z5',NULL),(7,'异常日志','~elmah.axd',9,'images/icon/5.png','Y','N','Z99',NULL),(8,'用户管理','admin/UserManager/UsersManage.aspx',9,'images/icon/6.png','Y','N','Z1',NULL),(9,'系统管理',NULL,0,'images/icon/76.png','Y','Y','Z',NULL),(21,'站内信','business/other/StandInsideLetter.aspx',0,'images/icon/12.png','Y','N','',''),(22,'站内信','business/other/StandInsideLetter.aspx',21,'images/icon/12.png','Y','N','',''),(23,'系统日志','admin/SystemLogs/SystemLog.aspx',9,'images/icon/13.png','Y','N','',''),(24,'基础数据设置','',0,'images/icon/77.png','Y','Y','Z1',''),(25,'省份信息管理','Business/BaseInfo/ProvieceList.aspx',24,'images/icon/4.png','Y','N','1',''),(26,'城市信息管理','Business/BaseInfo/CityList.aspx',24,'images/icon/4.png','Y','N','2',''),(27,'地址信息管理','Business/BaseInfo/AddressList.aspx',24,'images/icon/4.png','Y','N','3',''),(28,'总站信息管理','Business/BaseInfo/BigStationList.aspx',24,'images/icon/4.png','Y','N','4','');
/*!40000 ALTER TABLE `moudleinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `postinfo`
--

DROP TABLE IF EXISTS `postinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `postinfo` (
  `CODE` varchar(20) CHARACTER SET utf8 NOT NULL,
  `NAME` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `ISENABLE` char(1) DEFAULT 'Y',
  `REMARK` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `postinfo`
--

LOCK TABLES `postinfo` WRITE;
/*!40000 ALTER TABLE `postinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `postinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `powerinfo`
--

DROP TABLE IF EXISTS `powerinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `powerinfo` (
  `POWERID` int(11) NOT NULL AUTO_INCREMENT,
  `POWERNAME` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `POWERVALUE` int(11) DEFAULT NULL,
  `MOUDLEID` int(11) DEFAULT NULL,
  PRIMARY KEY (`POWERID`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `powerinfo`
--

LOCK TABLES `powerinfo` WRITE;
/*!40000 ALTER TABLE `powerinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `powerinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resourceinfo`
--

DROP TABLE IF EXISTS `resourceinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `resourceinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NAME` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `LOCATION` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `REMARK` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `ISENABLE` char(1) DEFAULT 'Y',
  `ISCONTROL` char(1) DEFAULT 'Y',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resourceinfo`
--

LOCK TABLES `resourceinfo` WRITE;
/*!40000 ALTER TABLE `resourceinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `resourceinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roleinfo`
--

DROP TABLE IF EXISTS `roleinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roleinfo` (
  `ROLEID` int(11) NOT NULL AUTO_INCREMENT,
  `ROLENAME` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `REMARK` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`ROLEID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roleinfo`
--

LOCK TABLES `roleinfo` WRITE;
/*!40000 ALTER TABLE `roleinfo` DISABLE KEYS */;
INSERT INTO `roleinfo` VALUES (9,'系统管理员','');
/*!40000 ALTER TABLE `roleinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolemoudleinfo`
--

DROP TABLE IF EXISTS `rolemoudleinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rolemoudleinfo` (
  `ROLEID` int(11) DEFAULT NULL,
  `MOUDLEID` int(11) DEFAULT NULL,
  `POWERVALUE` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolemoudleinfo`
--

LOCK TABLES `rolemoudleinfo` WRITE;
/*!40000 ALTER TABLE `rolemoudleinfo` DISABLE KEYS */;
INSERT INTO `rolemoudleinfo` VALUES (9,21,0),(9,22,0),(9,9,0),(9,23,0),(9,8,0),(9,3,0),(9,4,0),(9,2,0),(9,5,0),(9,6,0),(9,1,0),(9,7,0),(9,24,0),(9,25,0),(9,26,0),(9,27,0),(9,28,0);
/*!40000 ALTER TABLE `rolemoudleinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roleresourceinfo`
--

DROP TABLE IF EXISTS `roleresourceinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roleresourceinfo` (
  `ROLEID` int(11) NOT NULL,
  `RESOURCEID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roleresourceinfo`
--

LOCK TABLES `roleresourceinfo` WRITE;
/*!40000 ALTER TABLE `roleresourceinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `roleresourceinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `syslog`
--

DROP TABLE IF EXISTS `syslog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `syslog` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `usercode` varchar(20) DEFAULT NULL COMMENT '用户代码',
  `MOUDLEID` bigint(20) DEFAULT NULL COMMENT 'ID',
  `sj` datetime DEFAULT NULL COMMENT '登入时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=173 DEFAULT CHARSET=utf8 COMMENT='系统登入日志';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `syslog`
--

LOCK TABLES `syslog` WRITE;
/*!40000 ALTER TABLE `syslog` DISABLE KEYS */;
INSERT INTO `syslog` VALUES (1,'zengdl',8,'2014-04-23 13:04:09'),(2,'zengdl',3,'2014-04-23 13:04:11'),(3,'zengdl',2,'2014-04-23 13:04:12'),(4,'zengdl',4,'2014-04-23 13:04:13'),(5,'zengdl',7,'2014-04-23 13:05:47'),(6,'zengdl',1,'2014-04-23 13:05:47'),(7,'zengdl',22,'2014-04-23 17:41:45'),(8,'zengdl',22,'2014-04-23 17:45:07'),(9,'zengdl',22,'2014-04-23 17:56:15'),(10,'zengdl',22,'2014-04-23 17:56:40'),(11,'zengdl',22,'2014-04-23 17:57:10'),(12,'zengdl',22,'2014-04-23 17:57:55'),(13,'zengdl',22,'2014-04-23 17:58:24'),(14,'zengdl',22,'2014-04-23 17:59:21'),(15,'zengdl',22,'2014-04-23 18:00:11'),(16,'zengdl',22,'2014-04-23 18:01:39'),(17,'zengdl',22,'2014-04-23 18:02:55'),(18,'zengdl',22,'2014-04-23 18:03:12'),(19,'zengdl',22,'2014-04-23 18:06:19'),(20,'zengdl',22,'2014-04-23 18:06:53'),(21,'zengdl',22,'2014-04-23 18:07:12'),(22,'zengdl',22,'2014-04-23 18:07:22'),(23,'zengdl',22,'2014-04-23 18:07:33'),(24,'zengdl',22,'2014-04-23 18:07:47'),(25,'zengdl',22,'2014-04-23 18:08:30'),(26,'zengdl',22,'2014-04-23 18:08:35'),(27,'zengdl',22,'2014-04-23 18:08:56'),(28,'zengdl',22,'2014-04-23 18:09:23'),(29,'zengdl',22,'2014-04-23 18:10:42'),(30,'zengdl',22,'2014-04-23 18:10:59'),(31,'zengdl',22,'2014-04-23 18:12:08'),(32,'zengdl',22,'2014-04-23 18:12:36'),(33,'zengdl',22,'2014-04-23 18:12:57'),(34,'zengdl',22,'2014-04-23 18:13:37'),(35,'zengdl',22,'2014-04-23 18:13:58'),(36,'zengdl',22,'2014-04-23 18:14:17'),(37,'zengdl',8,'2014-04-23 18:50:58'),(38,'zengdl',8,'2014-04-23 19:20:57'),(39,'zengdl',4,'2014-04-23 19:20:58'),(40,'zengdl',3,'2014-04-23 19:21:47'),(41,'zengdl',6,'2014-04-23 19:21:50'),(42,'zengdl',6,'2014-04-23 19:21:52'),(43,'zengdl',23,'2014-04-23 19:25:12'),(44,'zengdl',23,'2014-04-23 19:25:30'),(45,'zengdl',23,'2014-04-23 19:26:02'),(46,'zengdl',23,'2014-04-23 19:26:21'),(47,'zengdl',23,'2014-04-23 19:26:25'),(48,'zengdl',23,'2014-04-23 19:26:41'),(49,'zengdl',23,'2014-04-23 19:27:49'),(50,'zengdl',23,'2014-04-23 19:28:21'),(51,'zengdl',23,'2014-04-23 19:29:11'),(52,'zengdl',23,'2014-04-23 19:29:30'),(53,'zengdl',23,'2014-04-23 19:29:32'),(54,'zengdl',23,'2014-04-23 19:29:33'),(55,'zengdl',23,'2014-04-23 19:29:55'),(56,'zengdl',8,'2014-04-23 19:29:59'),(57,'zengdl',3,'2014-04-23 19:30:01'),(58,'zengdl',4,'2014-04-23 19:30:02'),(59,'zengdl',2,'2014-04-23 19:30:03'),(60,'zengdl',5,'2014-04-23 19:30:04'),(61,'zengdl',6,'2014-04-23 19:30:06'),(62,'zengdl',1,'2014-04-23 19:30:07'),(63,'zengdl',7,'2014-04-23 19:30:08'),(64,'zengdl',23,'2014-04-23 19:30:10'),(65,'zengdl',23,'2014-04-23 19:30:31'),(66,'zengdl',23,'2014-04-23 19:30:44'),(67,'zengdl',23,'2014-04-23 19:30:53'),(68,'zengdl',23,'2014-04-23 19:31:54'),(69,'zengdl',23,'2014-04-23 19:33:48'),(70,'zengdl',23,'2014-04-23 19:33:51'),(71,'zengdl',23,'2014-04-23 19:34:31'),(72,'zengdl',23,'2014-04-23 19:34:39'),(73,'zengdl',23,'2014-04-23 19:34:40'),(74,'zengdl',23,'2014-04-23 19:34:42'),(75,'zengdl',23,'2014-04-23 19:34:57'),(76,'zengdl',23,'2014-04-23 19:35:46'),(77,'zengdl',23,'2014-04-23 19:35:51'),(78,'zengdl',23,'2014-04-23 19:35:53'),(79,'zengdl',23,'2014-04-23 19:35:55'),(80,'zengdl',23,'2014-04-23 19:36:18'),(81,'zengdl',23,'2014-04-23 19:36:20'),(82,'zengdl',23,'2014-04-23 19:36:26'),(83,'zengdl',4,'2014-04-26 11:06:47'),(84,'zengdl',3,'2014-04-26 11:08:00'),(85,'zengdl',8,'2014-04-26 11:08:03'),(86,'zengdl',1,'2014-04-26 11:08:10'),(87,'zengdl',6,'2014-04-26 11:08:12'),(88,'zengdl',5,'2014-04-26 11:08:14'),(89,'zengdl',2,'2014-04-26 11:08:16'),(90,'zengdl',6,'2014-04-26 11:08:25'),(91,'zengdl',2,'2014-04-26 11:08:31'),(92,'zengdl',2,'2014-04-26 11:08:33'),(93,'zengdl',2,'2014-04-26 11:08:40'),(94,'zengdl',4,'2014-04-26 11:08:42'),(95,'zengdl',8,'2014-05-05 09:33:33'),(96,'zengdl',22,'2014-05-05 09:36:06'),(97,'zengdl',1,'2014-05-05 09:36:15'),(98,'zengdl',6,'2014-05-05 09:36:17'),(99,'zengdl',5,'2014-05-05 09:36:20'),(100,'zengdl',8,'2014-05-07 11:13:16'),(101,'zengdl',2,'2014-05-07 11:13:19'),(102,'zengdl',5,'2014-05-07 11:13:22'),(103,'zengdl',8,'2014-05-07 17:03:39'),(104,'zengdl',8,'2014-05-07 17:03:49'),(105,'zengdl',3,'2014-05-07 17:03:51'),(106,'zengdl',2,'2014-05-07 17:03:54'),(107,'zengdl',4,'2014-05-07 17:03:55'),(108,'zengdl',1,'2014-05-07 17:04:01'),(109,'zengdl',23,'2014-05-07 17:11:19'),(110,'zengdl',7,'2014-05-07 17:11:36'),(111,'zengdl',22,'2014-05-07 17:17:58'),(112,'zengdl',22,'2014-05-07 17:18:21'),(113,'zengdl',22,'2014-05-07 17:19:26'),(114,'zengdl',22,'2014-05-07 17:19:34'),(115,'zengdl',22,'2014-05-07 17:19:46'),(116,'zengdl',8,'2014-05-07 17:19:51'),(117,'zengdl',8,'2014-05-07 17:19:53'),(118,'zengdl',8,'2014-05-07 17:20:13'),(119,'zengdl',8,'2014-05-07 17:20:21'),(120,'zengdl',8,'2014-05-07 17:20:27'),(121,'zengdl',8,'2014-05-07 17:20:30'),(122,'zengdl',8,'2014-05-07 17:20:34'),(123,'zengdl',8,'2014-05-07 17:20:38'),(124,'zengdl',8,'2014-05-07 17:20:42'),(125,'zengdl',8,'2014-05-07 17:20:59'),(126,'zengdl',23,'2014-05-07 17:21:01'),(127,'zengdl',23,'2014-05-07 17:21:04'),(128,'zengdl',7,'2014-05-07 17:21:07'),(129,'zengdl',1,'2014-05-07 17:21:09'),(130,'zengdl',22,'2014-05-07 17:21:13'),(131,'zengdl',22,'2014-05-07 17:21:18'),(132,'zengdl',22,'2014-05-07 17:21:24'),(133,'zengdl',22,'2014-05-07 17:21:30'),(134,'zhangyl',22,'2014-05-07 17:22:08'),(135,'zhangyl',6,'2014-05-07 17:22:31'),(136,'zhangyl',7,'2014-05-07 17:22:34'),(137,'zengdl',1,'2014-05-07 23:30:55'),(138,'zengdl',5,'2014-05-07 23:30:56'),(139,'zengdl',4,'2014-05-07 23:30:57'),(140,'zengdl',3,'2014-05-07 23:30:59'),(141,'zengdl',8,'2014-05-07 23:31:30'),(142,'zengdl',23,'2014-05-08 00:35:28'),(143,'zengdl',4,'2014-05-08 00:35:43'),(144,'zengdl',5,'2014-05-08 00:35:46'),(145,'zengdl',4,'2014-05-08 00:35:51'),(146,'zengdl',5,'2014-05-08 00:36:00'),(147,'zengdl',4,'2014-05-08 00:36:05'),(148,'zengdl',4,'2014-05-08 14:15:19'),(149,'zengdl',2,'2014-05-08 14:17:46'),(150,'zengdl',4,'2014-05-08 14:17:48'),(151,'zengdl',4,'2014-05-08 14:26:37'),(152,'zengdl',5,'2014-05-08 14:26:41'),(153,'zengdl',6,'2014-05-08 14:27:07'),(154,'zengdl',6,'2014-05-08 14:27:09'),(155,'zengdl',6,'2014-05-08 14:27:11'),(156,'zengdl',6,'2014-05-08 14:27:13'),(157,'zengdl',6,'2014-05-08 14:27:19'),(158,'zengdl',5,'2014-05-08 14:28:18'),(159,'zengdl',2,'2014-05-08 14:28:23'),(160,'zengdl',4,'2014-05-08 14:28:26'),(161,'zengdl',6,'2014-05-08 14:33:56'),(162,'zengdl',6,'2014-05-08 14:33:57'),(163,'zengdl',6,'2014-05-08 14:34:03'),(164,'zengdl',6,'2014-05-08 14:35:52'),(165,'zengdl',2,'2014-05-08 14:35:56'),(166,'zengdl',4,'2014-05-08 14:35:57'),(167,'zengdl',8,'2014-05-08 14:36:11'),(168,'zengdl',3,'2014-05-08 14:36:31'),(169,'zengdl',8,'2014-05-08 14:36:35'),(170,'zengdl',23,'2014-05-08 14:36:37'),(171,'zengdl',23,'2014-05-08 14:36:40'),(172,'zengdl',8,'2014-05-08 14:36:42');
/*!40000 ALTER TABLE `syslog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userinfo`
--

DROP TABLE IF EXISTS `userinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userinfo` (
  `USERID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `USERCODE` varchar(20) CHARACTER SET utf8 NOT NULL COMMENT '用户编号',
  `USERNAME` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '用户名',
  `PASSWORD` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '密码',
  `EMAIL` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '邮箱',
  `ADDRESS` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '地址',
  `DEPTID` varchar(10) CHARACTER SET utf8 DEFAULT NULL COMMENT '部门ID',
  `POSTCODE` varchar(10) CHARACTER SET utf8 DEFAULT NULL COMMENT '邮编',
  `TELEPHONE` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '电话',
  `MOBILE` varchar(15) CHARACTER SET utf8 DEFAULT NULL COMMENT '邮箱',
  `ISENABLE` char(1) DEFAULT 'Y' COMMENT '是否可用',
  `ZD` varchar(10) CHARACTER SET utf8 DEFAULT NULL COMMENT '站点',
  PRIMARY KEY (`USERID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userinfo`
--

LOCK TABLES `userinfo` WRITE;
/*!40000 ALTER TABLE `userinfo` DISABLE KEYS */;
INSERT INTO `userinfo` VALUES (13,'zengdl','曾地理','123','','','LS','','46281136@qq.com','','Y',''),(14,'zhangyl','Kevin Zhang','123','','','LS','','','','Y','');
/*!40000 ALTER TABLE `userinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroleinfo`
--

DROP TABLE IF EXISTS `userroleinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userroleinfo` (
  `USERID` int(11) NOT NULL COMMENT '用户ID',
  `ROLEID` int(11) NOT NULL COMMENT '权限ID',
  PRIMARY KEY (`USERID`,`ROLEID`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroleinfo`
--

LOCK TABLES `userroleinfo` WRITE;
/*!40000 ALTER TABLE `userroleinfo` DISABLE KEYS */;
INSERT INTO `userroleinfo` VALUES (13,9),(14,9);
/*!40000 ALTER TABLE `userroleinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-05-09 12:49:34
