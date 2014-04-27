-- TEAM5OCGS DATABASE Team

-- script to create TEAM5OCGS backend

DROP TABLE customer CASCADE CONSTRAINTS;
DROP TABLE employee CASCADE CONSTRAINTS;
DROP TABLE book CASCADE CONSTRAINTS;
DROP TABLE author CASCADE CONSTRAINTS;
DROP TABLE publisher CASCADE CONSTRAINTS;
DROP TABLE orders CASCADE CONSTRAINTS;
DROP TABLE order_item CASCADE CONSTRAINTS;
DROP TABLE shopping_cart CASCADE CONSTRAINTS;
DROP TABLE testimonials CASCADE CONSTRAINTS;
DROP TABLE promotion CASCADE CONSTRAINTS;

CREATE TABLE Customer (
customer_id INTEGER,
l_name VARCHAR2(20),
f_name VARCHAR2(20),
bs_address VARCHAR2(20),
bs_city VARCHAR2(20),
bs_state VARCHAR2(20),
bs_zip INTEGER,
region VARCHAR2(5),
user_name VARCHAR2(20) UNIQUE,
password VARCHAR2(20),
email VARCHAR2(40),
PRIMARY KEY (customer_id),
CHECK (LENGTH(user_name) >= 3 AND LENGTH(password) >= 3)
);

CREATE TABLE Employee (
employee_id INTEGER,
f_name VARCHAR2(20),
l_name VARCHAR2(20),
user_name VARCHAR2(20),
password VARCHAR2(20),
role VARCHAR2(10),
start_date DATE,
end_date DATE,
commission REAL,
region VARCHAR2(5),
email VARCHAR2(40),
PRIMARY KEY (employee_id),
CHECK (LENGTH(user_name) >= 3 AND LENGTH(password) >= 3)
);

CREATE TABLE Author (
author_id CHAR(4),
l_name VARCHAR2(20),
f_name VARCHAR2(20),
PRIMARY KEY(author_id)
);

CREATE TABLE Publisher (
publisher_id INTEGER,
name VARCHAR2(40),
contact VARCHAR2(30),
email VARCHAR2(40),
PRIMARY KEY(publisher_id)
);

CREATE TABLE BOOK (
isbn CHAR(10),
title VARCHAR2(40),
author_id CHAR(4),
publication_date DATE,
q_o_h INTEGER,
wholesale_cost REAL,
retail_price REAL,
category VARCHAR2(15),
publisher_id INTEGER,
filename VARCHAR2(30),
summary VARCHAR2(150),
PRIMARY KEY (isbn),
FOREIGN KEY(author_id) REFERENCES Author,
FOREIGN KEY(publisher_id) REFERENCES Publisher
);

CREATE TABLE Orders (
order_no INTEGER,
customer_id INTEGER,
order_date DATE,
ship_date DATE,
ship_street VARCHAR2(20),
ship_city VARCHAR2(15),
ship_state VARCHAR2(15),
ship_zip INTEGER,
PRIMARY KEY(order_no),
FOREIGN KEY(customer_id) REFERENCES Customer
);

CREATE TABLE Order_item(
order_no INTEGER,
item_no INTEGER,
isbn CHAR(10),
quantity INTEGER,
PRIMARY KEY (order_no, isbn),
FOREIGN KEY (order_no) REFERENCES Orders,
FOREIGN KEY (isbn) REFERENCES Book
);

CREATE TABLE Shopping_cart(
session_id VARCHAR2(30),
isbn CHAR(10),
quantity INTEGER,
FOREIGN KEY (isbn) REFERENCES Book
);

CREATE TABLE Testimonials(
test_id INTEGER,
customer_id INTEGER,
text VARCHAR2(250),
PRIMARY KEY(test_id),
FOREIGN KEY(customer_id) REFERENCES Customer
);

CREATE TABLE Promotion(
promotion_id INTEGER,
promotion_type VARCHAR2(35),
items_ordered INTEGER,
customer_id INTEGER,
PRIMARY KEY(promotion_id),
FOREIGN KEY(customer_id) REFERENCES Customer
);

-- view to query book table

CREATE OR REPLACE VIEW BOOK_VIEW AS
SELECT isbn, title, l_name, f_name, q_o_h, retail_price, category, filename, summary, wholesale_cost
FROM BOOK B, AUTHOR A
WHERE A.author_id = B.author_id;



--view used by the shopping cart code

CREATE OR REPLACE VIEW CART_VIEW AS
SELECT S.isbn, title, session_id, quantity, l_name, f_name, retail_price, category, q_o_h
FROM BOOK B, AUTHOR A, SHOPPING_CART S
WHERE A.author_id = B.author_id 
AND S.isbn = B.isbn;

--trigger to send email when qoh < 1



--auto increment triggers are declared after all the data inserts, at the end of this document




--used to auto increment the primary key of the orders table

drop sequence orders_seq;
create sequence orders_seq start with 1021 increment by 1;

--stored procedure
--takes a session id, customer id, and shipping address
--creates an order in the order table
--deletes all session entries in the shopping cart
--creates entries in order_item for each book in the order

CREATE OR REPLACE PROCEDURE checkout(
  s_id VARCHAR2,
  c_id INTEGER,  
  x_street VARCHAR2,
  x_city VARCHAR2,
  x_state VARCHAR2,
  x_zip INTEGER) 
AS
  x_isbn CHAR(10);
  x_quantity INTEGER;
  x_item_no INTEGER;
  x_order_id INTEGER;
  CURSOR CART_CURSOR IS
    SELECT isbn, quantity
    FROM SHOPPING_CART
    WHERE session_id = s_id
    FOR UPDATE;  
BEGIN      
  INSERT INTO ORDERS VALUES (orders_seq.nextval, c_id, sysdate, sysdate, x_street, x_city, x_state, x_zip);
  OPEN CART_CURSOR;
  LOOP
    FETCH CART_CURSOR INTO x_isbn, x_quantity;
    EXIT WHEN CART_CURSOR%NOTFOUND;
    DELETE FROM SHOPPING_CART WHERE CURRENT OF CART_CURSOR;
    INSERT INTO ORDER_ITEM VALUES (orders_seq.currval, 1, x_isbn, x_quantity);
  END LOOP;
END;
.
run;

-- insert into tables as requested by client

INSERT INTO AUTHOR VALUES ('S100','SMITH', 'SAM');
INSERT INTO AUTHOR VALUES ('J100','JONES','JANICE');
INSERT INTO AUTHOR VALUES ('A100','AUSTIN','JAMES');
INSERT INTO AUTHOR VALUES ('M100','MARTINEZ','SHEILA');
INSERT INTO AUTHOR VALUES ('K100','KZOCHSKY','TAMARA');
INSERT INTO AUTHOR VALUES ('P100','PORTER','LISA');
INSERT INTO AUTHOR VALUES ('A105','ADAMS','JUAN');
INSERT INTO AUTHOR VALUES ('B100','BAKER','JACK');
INSERT INTO AUTHOR VALUES ('P105','PETERSON','TINA');
INSERT INTO AUTHOR VALUES ('W100','WHITE','WILLIAM');
INSERT INTO AUTHOR VALUES ('W105','WHITE','LISA');
INSERT INTO AUTHOR VALUES ('R100','ROBINSON','ROBERT');
INSERT INTO AUTHOR VALUES ('F100','FIELDS','OSCAR');
INSERT INTO AUTHOR VALUES ('W110','WILKINSON','ANTHONY');

INSERT INTO PUBLISHER VALUES (1,'PRINTING IS US','TOMMIE SEYMOUR','TSeymour@printingisus.com');
INSERT INTO PUBLISHER VALUES (2,'PUBLISH OUR WAY','JANE TOMLIN',' JTomlin@publishourway.com');
INSERT INTO PUBLISHER VALUES (3,'AMERICAN PUBLISHING','DAVID DAVIDSON','DDavidson@americanpublishing.com');
INSERT INTO PUBLISHER VALUES (4,'READING MATERIALS INC.','RENEE SMITH','RSmith@readingmaterials.com');
INSERT INTO PUBLISHER VALUES (5,'REED-N-RITE','SEBASTIAN JONES','SJones@readnrite.com');

INSERT INTO BOOK VALUES ('1059831198','BODY BUILD IN 10 MINUTES A DAY','S100','21-JAN-01', 4, 18.75, 30.95, 'FITNESS', 3, 'body_build.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('0401140733','REVENGE OF MICKEY','J100','14-DEC-01', 1, 14.20, 22.00, 'FAMILY LIFE', 3, 'mickey.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('4981341710','BUILDING A CAR WITH  TOOTHPICKS','A100','18-MAR-02', 2, 37.80,59.95, 'CHILDREN', 3, 'building_a_car.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('8843172113','DATABASE IMPLEMENTATION','M100','04-JUN-99', 3, 31.40, 55.95, 'COMPUTER', 3, 'database_implementation.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('3437212490','COOKING WITH MUSHROOMS','K100','28-FEB-00', 4, 12.50, 19.95, 'COOKING', 3, 'cooking_with_mushrooms.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('3957136468','HOLY GRAIL OF ORACLE','P100','31-DEC-01', 3, 47.25, 75.95, 'COMPUTER', 3, 'holy_grail_oracle.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('1915762492','HANDCRANKED COMPUTERS','A105','21-JAN-01', 3, 21.80, 25.00, 'COMPUTER', 3, 'computers.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('9959789321','E-BUSINESS THE EASY WAY','B100','01-MAR-02', 2, 37.90, 54.50, 'COMPUTER', 3, 'e_business.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('2491748320','PAINLESS CHILD-REARING','P105','17-JUL-00', 5, 48.00, 89.95, 'FAMILY LIFE', '3', 'child_rearing.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('0299282519','THE WOK WAY TO COOK','W100','11-SEP-00', 4, 19.00, 28.75, 'COOKING', 3, 'wok_cook.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('8117949391','BIG BEAR AND LITTLE DOVE','W105','08-NOV-01', 5, 5.32, 8.95, 'CHILDREN', 3, 'big_bear_little_dove.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('0132149871','HOW TO GET FASTER PIZZA','R100','11-NOV-02', 4, 17.85, 29.95, 'SELF HELP', 3, 'faster_pizza.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('9247381001','HOW TO MANAGE THE MANAGER','F100','09-MAY-99', 1, 15.40, 31.95, 'BUSINESS', 3, 'manage_the_manager.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');
INSERT INTO BOOK VALUES ('2147428890','SHORTEST POEMS','W110','01-MAY-01', 5, 21.85, 39.95, 'LITERATURE', 3, 'short_poems.jpg', 'As a book for programmers who want to learn Python, it does a very good job. The coverage is informative and well ordered.');

INSERT INTO CUSTOMER VALUES (1001, 'MORALES', 'BONITA', 'P.O. BOX 651', 'EASTPOINT', 'FL', 32328, 'SE', 'BMorales', 'BMorales#', '');
INSERT INTO CUSTOMER VALUES (1002, 'THOMPSON', 'RYAN', 'P.O. BOX 9835', 'SANTA MONICA', 'CA', 90404,'W', 'RThompson','RThompson#','');
INSERT INTO CUSTOMER VALUES (1003, 'SMITH', 'LEILA', 'P.O. BOX 66', 'TALLAHASSEE', 'FL',  '32306', 'SE', 'LSmith', 'LSmith#', '');
INSERT INTO CUSTOMER VALUES (1004, 'PIERSON', 'THOMAS', '69821 SOUTH AVENUE', 'BOISE', 'ID',  '83707', 'SW', 'TPierson', 'TPierson#', '');
INSERT INTO CUSTOMER VALUES (1005,'GIRARD', 'CINDY', 'P.O. BOX 851', 'SEATTLE', 'WA', '98115', 'W', 'CGirard', 'CGirard#', 'TEAM5OCGSCustomer5@gmail.com');
INSERT INTO CUSTOMER VALUES (1006, 'CRUZ', 'MESHIA', '82 DIRT ROAD', 'ALBANY', 'NY', '12211', 'NE', 'MCruz', 'MCruz#', '');
INSERT INTO CUSTOMER VALUES (1007, 'GIANA', 'TAMMY', '9153 MAIN STREET', 'AUSTIN', 'TX',  '78710','N', 'TGiana', 'TGiana#', '');
INSERT INTO CUSTOMER VALUES (1008, 'JONES', 'KENNETH', 'P.O. BOX 137', 'CHEYENNE', 'WY',  '82003','SW', 'KJones', 'KJones#', ' ');
INSERT INTO CUSTOMER VALUES (1009, 'PEREZ', 'JORGE', 'P.O. BOX 8564', 'BURBANK', 'CA', '91510', 'W', 'JPerez', 'JPerez#', 'TEAM5OCGSCustomer9@gmail.com');
INSERT INTO CUSTOMER VALUES (1010, 'LUCAS', 'JAKE', '114 EAST SAVANNAH', 'ATLANTA', 'GA',  '30314','SE', 'JLucas', 'JLucas#', '' );
INSERT INTO CUSTOMER VALUES (1011, 'MCGOVERN', 'REESE', 'P.O. BOX 18', 'CHICAGO', 'IL',  '60606', 'NW', 'RMCGovern', 'RMCGovern#', ' ');
INSERT INTO CUSTOMER VALUES (1012, 'MCKENZIE', 'WILLIAM', 'P.O. BOX 971', 'BOSTON', 'MA',  '02110', 'NE', 'WMCKenzie', 'WMCKenzie#', '');
INSERT INTO CUSTOMER VALUES (1013, 'NGUYEN', 'NICHOLAS', '357 WHITE EAGLE AVE.', 'CLERMONT',  'FL', '34711', 'SE', 'NNguyen', 'NNguyen#', '');
INSERT INTO CUSTOMER VALUES (1014, 'LEE', 'JASMINE', 'P.O. BOX 2947', 'CODY', 'WY', '82414', 'SW', 'JLee', 'JLee#', '');
INSERT INTO CUSTOMER VALUES (1015, 'SCHELL', 'STEVE', 'P.O. BOX 677', 'MIAMI', 'FL', '33111', 'SE', 'SSchell', 'SSchell#', ' ');
INSERT INTO CUSTOMER VALUES (1016, 'DAUM', 'MICHELL', '9851231 LONG ROAD', 'BURBANK', 'CA',  '91508', 'W', 'MDaum', 'MDaum#', ' ');
INSERT INTO CUSTOMER VALUES (1017, 'NELSON', 'BECCA', 'P.O. BOX 563', 'KALMAZOO', 'MI',  '49006', 'NW', 'BNelson', 'BNelson#', ' ');
INSERT INTO CUSTOMER VALUES (1018, 'MONTIASA', 'GREG', '1008 GRAND AVENUE', 'MACON', 'GA',  '31206', 'SE', 'GMontiasa', 'GMontiasa#', ' ');
INSERT INTO CUSTOMER VALUES (1019, 'SMITH', 'JENNIFER', 'P.O. BOX 1151', 'MORRISTOWN', 'NJ',  '07962', 'E', 'JSmith', 'JSmith#', ' ');
INSERT INTO CUSTOMER VALUES (1020, 'FALAH', 'KENNETH', 'P.O. BOX 335', 'TRENTON', 'NJ',  '08607', 'E', 'KFalah', 'KFalah#', ' ');


INSERT INTO ORDERS VALUES (1000,1005,'31-MAR-11','02-APR-11','1201 ORANGE AVE', 'SEATTLE', 'WA', '98114');
INSERT INTO ORDERS VALUES (1001,1010,'31-MAR-11','01-APR-11', '114 EAST SAVANNAH', 'ATLANTA', 'GA', '30314');
INSERT INTO ORDERS VALUES (1002,1011,'31-MAR-11','01-APR-11','58 TILA CIRCLE', 'CHICAGO', 'IL', '60605');
INSERT INTO ORDERS VALUES (1003,1001,'01-APR-11','01-APR-11','958 MAGNOLIA LANE', 'EASTPOINT', 'FL', '32328');
INSERT INTO ORDERS VALUES (1004,1020,'01-APR-11','05-APR-11','561 ROUNDABOUT WAY', 'TRENTON', 'NJ', '08601');
INSERT INTO ORDERS VALUES (1005,1018,'01-APR-11','02-APR-11', '1008 GRAND AVENUE', 'MACON', 'GA', '31206');
INSERT INTO ORDERS VALUES (1006,1003,'01-APR-11','02-APR-11','558A CAPITOL HWY.', 'TALLAHASSEE', 'FL', '32307');
INSERT INTO ORDERS VALUES (1007,1007,'02-APR-11','04-APR-11', '9153 MAIN STREET', 'AUSTIN', 'TX', '78710');
INSERT INTO ORDERS VALUES (1008,1004,'02-APR-11','03-APR-11', '69821 SOUTH AVENUE', 'BOISE', 'ID', '83707');
INSERT INTO ORDERS VALUES (1009,1005,'03-APR-11','05-APR-11','9 LIGHTENING RD.', 'SEATTLE', 'WA', '98110');
INSERT INTO ORDERS VALUES (1010,1019,'03-APR-11','04-APR-11','384 WRONG WAY HOME', 'MORRISTOWN', 'NJ', '07960');
INSERT INTO ORDERS VALUES (1011,1010,'03-APR-11','05-APR-11', '102 WEST LAFAYETTE', 'ATLANTA', 'GA', '30311');
INSERT INTO ORDERS VALUES (1012,1017,'03-APR-11',NULL,'1295 WINDY AVENUE', 'KALMAZOO', 'MI', '49002');
INSERT INTO ORDERS VALUES (1013,1014,'03-APR-11','04-APR-11','7618 MOUNTAIN RD.', 'CODY', 'WY', '82414');
INSERT INTO ORDERS VALUES (1014,1007,'04-APR-11','05-APR-11', '9153 MAIN STREET', 'AUSTIN', 'TX', '78710');
INSERT INTO ORDERS VALUES (1015,1020,'04-APR-11',NULL,'557 GLITTER ST.', 'TRENTON', 'NJ', '08606');
INSERT INTO ORDERS VALUES (1016,1003,'04-APR-11',NULL,'9901 SEMINOLE WAY', 'TALLAHASSEE', 'FL', '32307');
INSERT INTO ORDERS VALUES (1017,1015,'04-APR-11','05-APR-11','887 HOT ASPHALT ST', 'MIAMI', 'FL', '33112');
INSERT INTO ORDERS VALUES (1018,1001,'05-APR-11',NULL,'95812 HIGHWAY 98', 'EASTPOINT', 'FL', '32328');
INSERT INTO ORDERS VALUES (1019,1018,'05-APR-11',NULL, '1008 GRAND AVENUE', 'MACON', 'GA', '31206');
INSERT INTO ORDERS VALUES (1020,1008,'05-APR-11',NULL,'195 JAMISON LANE', 'CHEYENNE', 'WY', '82003');


INSERT INTO Order_item VALUES (1000,1,'3437212490',1); 
INSERT INTO Order_item VALUES (1001,1,'9247381001',1); 
INSERT INTO Order_item VALUES (1001,2,'2491748320',1); 
INSERT INTO Order_item VALUES (1002,1,'8843172113',2); 
INSERT INTO Order_item VALUES (1003,1,'8843172113',1); 
INSERT INTO Order_item VALUES (1003,2,'1059831198',1);
INSERT INTO Order_item VALUES (1003,3,'3437212490',1);
INSERT INTO Order_item VALUES  (1004,1,'2491748320',2);
INSERT INTO Order_item VALUES  (1005,1,'2147428890',1);
INSERT INTO Order_item VALUES  (1006,1,'9959789321',1);
INSERT INTO Order_item VALUES  (1007,1,'3957136468',3);
INSERT INTO Order_item VALUES  (1007,2,'9959789321',1);
INSERT INTO Order_item VALUES  (1007,3,'8117949391',1);
INSERT INTO Order_item VALUES  (1007,4,'8843172113',1);
INSERT INTO Order_item VALUES  (1008,1,'3437212490',2);
INSERT INTO Order_item VALUES (1009,1,'3437212490',1);
INSERT INTO Order_item VALUES  (1009,2,'0401140733',1);
INSERT INTO Order_item VALUES  (1010,1,'8843172113',1);
INSERT INTO Order_item VALUES  (1011,1,'2491748320',1);
INSERT INTO Order_item VALUES  (1012,1,'8117949391',1);
INSERT INTO Order_item VALUES  (1012,2,'1915762492',2);
INSERT INTO Order_item VALUES  (1012,3,'2491748320',1);
INSERT INTO Order_item VALUES  (1012,4,'0401140733',1);
INSERT INTO Order_item VALUES  (1013,1,'8843172113',1);
INSERT INTO Order_item VALUES  (1014,1,'0401140733',2);
INSERT INTO Order_item VALUES  (1015,1,'3437212490',1);
INSERT INTO Order_item VALUES  (1016,1,'2491748320',1);
INSERT INTO Order_item VALUES  (1017,1,'8117949391',2);
INSERT INTO Order_item VALUES  (1018,1,'3437212490',1);
INSERT INTO Order_item VALUES  (1018,2,'8843172113',1);
INSERT INTO Order_item VALUES  (1019,1,'0401140733',1);
INSERT INTO Order_item VALUES  (1020,1,'3437212490',1);

INSERT INTO EMPLOYEE VALUES (01, 'CUSTOMER SERVICE', 'REPRESENTATIVE', 'CSR', 'CSR#',  'CSR', '04-APR-10',NULL,  NULL,  
NULL, 'TEAM5OCGSCSR@gmail.com' ); 
INSERT INTO EMPLOYEE VALUES (02, 'DATA ENTRY', 'CLERK', 'DEC', 'DEC#', 'DEC','04-APR-01',NULL,NULL, NULL, 'TEAM5OCGSDEC@gmail.com');
INSERT INTO EMPLOYEE VALUES (03, 'THE', 'MANAGER', 'MANAGER', 'MANAGER#',  'M',    '04-APR-08',NULL,   NULL ,  
NULL, 'TEAM5OCGSM@gmail.com' );
INSERT INTO EMPLOYEE VALUES (04, 'ACCOUNT 1', 'MANAGER', 'ACCOUNT1MANAGER', 'ACCOUNT1MANAGER#', 'AM', '04-APR-10',NULL, NULL, 'W', 'TEAM5OCGSAM1@gmail.com' );
INSERT INTO EMPLOYEE VALUES (05, 'ACCOUNT 2', 'MANAGER', 'ACCOUNT2MANAGER', 'ACCOUNT2MANAGER#', 'AM', '04-APR-09',NULL, NULL, 'E' , '' );
INSERT INTO EMPLOYEE VALUES (06, 'ACCOUNT 3', 'MANAGER', 'ACCOUNT3MANAGER', 'ACCOUNT3MANAGER#', 'AM', '04-APR-08',NULL, NULL,'N' ,'');
INSERT INTO EMPLOYEE VALUES (07, 'ACCOUNT 4', 'MANAGER', 'ACCOUNT4MANAGER', 'ACCOUNT4MANAGER#', 'AM', '04-APR-07',NULL, NULL, 'SW' ,'');
INSERT INTO EMPLOYEE VALUES (08, 'ACCOUNT 5', 'MANAGER', 'ACCOUNT5MANAGER', 'ACCOUNT5MANAGER#', 'AM', '04-APR-06',NULL, NULL, 'SE' ,'');
INSERT INTO EMPLOYEE VALUES (09, 'ACCOUNT 6', 'MANAGER', 'ACCOUNT6MANAGER', 'ACCOUNT6MANAGER#', 'AM', '04-APR-05',NULL, NULL,'NW' ,'');

--these triggers and sequences implement auto incrementing primary keys for the order and --customer tables.
--THIS TRIGGER MUST BE DECLARED “AFTER” ALL THE CUSTOMER DATA IS INSERTED!

drop sequence customer_seq;
create sequence customer_seq start with 1021 increment by 1;

create or replace trigger customer_autoinc_trigger
before insert on customer
for each row
begin
select customer_seq.nextval into :new.customer_id from dual;
end;
/