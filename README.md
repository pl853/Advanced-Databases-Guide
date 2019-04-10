# Advanced-Databases

E-R Models </br>
Are the highest level of models when database modelling, it models the conceptual aspect of the database.
 - entity 
 - attributes
 - relations:
    - 1-1
    - 1-N
    - N-M
 - Keys
 - Weak entities

Relational model
A model halfway between a conceptual model and the physical model, it contains an abstraction of physical elements
 - relation
 - Keys

SQL </br>
SQL is a language than declares the WHAT and not the HOW.
The language consist of four categories.

The Data Definition Language (DDL) is used to create relations (tables).

Data Manipulation Language (DML) is used to insert,modify and extract data from relations (tables).

Data Control Language (DCL) is used to grant controle to tables,views and databases.

Transaction Control language (TCL) is used to create transactions and control them.

{examples will be implented later}

Normalization </br>
The main reason normalization is used is because it improves the way the database is designed. It is the process of converting the tables of a database into other tables in some normal form( will be explained later). Normalization uses decomposition to eliminate anomalies and redundancy. This is neccesary since it wil:
- minimze te storage space used by relations
  When you join two separate tables you use less storage space then putting everything in the same table.
- eliminate anomalies in a database (redundancy | overbodigheden)
  When updating a database which has anomalies there will be null values needed. 
  When deleting a database which has anomalies there will be more info removed than needed.
  When modifying a database which has anomalies you have to modify every tuple by hand because it will not reflect the modification in al the tuples.
- eliminate spurious tuples
  spurious tuples are created when joining 2 tables that are not designed correctly. Normalization makes sure that the decomposition doesn't create spurious tuples

Normal forms </br>
They are properties that a relation must satisfy. You can devide the term normal forms in 2 differen kinds:
- Historical definitions </br>
  The original definitions defined by the code, taking into account only the primary key.
- Refined definitions </br>
  A refinement of the normal forms that also takes the candidate keys into account.

The first normal form [1NF] </br> will be automaticly given by the relational model unless the ERD is not translated correctly in the relational model. All your relations should be 1NF.
You can see if a table is in 1NF by checking wether a row has multiple values for one attribute. If this is the case the table is not in 1NF. 

The second normal form [2NF] </br>

{examples will be implented later}

Functional dependencies </br>
Are dependencies that are defined by the designer. They cant be infered by reading data from the database table, instead they should be read in the documentation of the database. Only if there is no documentation provided with the database, you can try to infer functional dependencies from the data.

{examples will be implented later}


Normalization on candidate keys </br>
