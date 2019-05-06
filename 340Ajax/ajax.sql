-- If you want to make it work for yourself, you'll need to create the table!
-- 
-- Table structure for table `536AjaxClass`
-- 

DROP TABLE IF EXISTS '340AjaxClass';
CREATE TABLE `340AjaxClass` (
  `id` tinyint(4) NOT NULL auto_increment,
  `name` varchar(20) NOT NULL default '',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM AUTO_INCREMENT=3 ;

-- 
-- Dumping data for table `536AjaxClass`
-- 

INSERT INTO `340AjaxClass` VALUES (1, 'Dan Bogaard');
INSERT INTO `340AjaxClass` VALUES (2, 'Tona Henderson'); 
INSERT INTO `340AjaxClass` VALUES (3, 'Michael Floeser'); 