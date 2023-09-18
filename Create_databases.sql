SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`News`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`News` (
  `idNews` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  `Content` MEDIUMTEXT NOT NULL,
  `DateTime` DATETIME NOT NULL,
  `Positivity` INT NOT NULL,
  PRIMARY KEY (`idNews`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`News_db`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`News_db` (
  `idNews` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  `Content` MEDIUMTEXT NOT NULL,
  `Positivity` INT NOT NULL,
  `DateTime` DATETIME NOT NULL,
  PRIMARY KEY (`idNews`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Users_db`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Users_db` (
  `idUsers` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(30) NOT NULL,
  `Password` VARCHAR(32) NOT NULL,
  `Email` VARCHAR(255) NULL,
  `Create_time` DATETIME NULL,
  PRIMARY KEY (`idUsers`));


-- -----------------------------------------------------
-- Table `mydb`.`Users_db`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Users_db` (
  `idUsers` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(30) NOT NULL,
  `Password` VARCHAR(32) NOT NULL,
  `Email` VARCHAR(255) NULL,
  `Create_time` DATETIME NULL,
  PRIMARY KEY (`idUsers`));


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
