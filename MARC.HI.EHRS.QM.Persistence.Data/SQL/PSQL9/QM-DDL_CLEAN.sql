/* 
 * POSTGREQM - MARC-HI QUERY MANAGER
 * VERSION: 3.0
 * AUTHOR: JUSTIN FYFE
 * DATE: DECEMBER 30, 2010
 * FILES:
 *	QM.SQL		- SQL CODE TO CREATE TABLES, INDECIES, VIEWS AND SEQUENCES AND FUNCTIONS
 * DESCRIPTION:
 *	THIS FILE CLEANS AND THEN RE-CREATES THE POSTGRESQL QUERY MANAGER TABLES
 *	DATABASE SCHEMA INCLUDING TABLES, VIEWS, INDECIES, SEQUENCES AND FUNCTIONS. 
 * LICENSE:
 * 	Licensed under the Apache License, Version 2.0 (the "License");
 * 	you may not use this file except in compliance with the License.
 * 	You may obtain a copy of the License at
 *
 *     		http://www.apache.org/licenses/LICENSE-2.0
 *
 * 	Unless required by applicable law or agreed to in writing, software
 * 	distributed under the License is distributed on an "AS IS" BASIS,
 * 	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * 	See the License for the specific language governing permissions and
 * 	limitations under the License.
 *
 * REMARKS:
 *	THE SCHEMA THAT IS CREATED BY THIS FILE SHOULD NOT BE CONFUSED WITH THE
 *	SCHEMA FOR THE MESSAGE BOX SERVICE. THE MESSAGE BOX SERVICE SCHEMA IS
 *	INTENDED FOR NOT ONLY TRACKING REQUEST/RESPONSE PAIRS BUT FOR TRACKING
 *	THE RESPONSE TO QUEUED MODE OPERATIONS.
 */
--CREATE LANGUAGE PLPGSQL;

/*
 * TABLES
 */
DROP SEQUENCE QRY_RSLT_SEQ CASCADE;
DROP TABLE QRY_RSLT_TBL CASCADE;
DROP TABLE QRY_TBL CASCADE;

/*
 * FUNCTIONS
 */

-- @PROCEDURE
-- REGISTERS A QUERY WITH THE PERSISTANCE
DROP FUNCTION IF EXISTS REG_QRY 
(
VARCHAR,
DECIMAL,
BYTEA
) ;

-- @PROCEDURE
-- PUSH A QUERY RESULT INTO A RESULT SET
DROP FUNCTION IF EXISTS PUSH_QRY_RSLT
(
VARCHAR,
DECIMAL,
DECIMAL
) ;

-- @PROCEDURE
-- PUSH A QUERY RESULT INTO A RESULT SET
DROP FUNCTION IF EXISTS PUSH_QRY_RSLTS
(
VARCHAR,
VARCHAR
) ;


-- @FUNCTION
-- POP THE SPECIFIED NUMBER OF RESULTS
-- RETURNS: SET OF DECIMALS
DROP FUNCTION IF EXISTS GET_QRY_RSLTS
(
VARCHAR,
DECIMAL,
DECIMAL
);

-- @FUNCTION
-- GET THE NUMBER OF UN-POPPED RECORDS LEFT
DROP FUNCTION IF EXISTS GET_QRY_CNT
(
VARCHAR
) ;

-- @FUNCTION
-- DETERMINE IF THE QUERY HAS BEEN REGISTERED
DROP FUNCTION IF EXISTS IS_QRY_REG
(
VARCHAR
) ;

-- @FUNCTION
-- CLEAN STALE QUERIES
DROP FUNCTION IF EXISTS QRY_CLN
(
VARCHAR
) ;

DROP FUNCTION IF EXISTS GET_QRY_TAG
(
VARCHAR
) ;