# Advanced-Databases

E-R Models
Are the highest level of models when database modelling, it models the conceptual aspect of the database.
 - Entities </br>
   Anything that can exist on its own in the database. For example, take a database from a space shooter game. Starships, astroids and weapons could be entities in this database.
 - Attributes</br>
   Are characteristic of an entity. For example, take a starship as an entity. Atributes of this entity coulde be: 
   - The velocity of the ship.
   - The strenght of the ship.
   - The damage of the ship.
 - Relations</br>
   Describe the relations between entities. The amount of participants, also called cardinalitie, can differ per entity. The possible cardinalities are:
    - 1-1 Ex. one pilot drives one spaceship
    - 1-N Ex. one pilot drives multiple spaceships
    - N-M EX. multiple pilots can drive multiple spaceships
 - Keys</br>
   Are used to uniquely identify an entity, it can be a single or a set of attributes that define an entity. 
   - Ex 1. An id for a starship. In this example starships can't have the same key.
   - Ex 2. A firstname and a lastname for a person combined. In this case a people can't have the same combination of firstname and lastname.
 - Weak entities </br>
   Are attributes that don't have to be or are not unique. Ex. the speed of a starship. Multiple starships can have te same speed.

Relational model </br>
A model halfway between a conceptual model and the physical model, it contains an abstraction of physical elements.
 - Relation </br>
   In a relational model a relation is a collection of tuples (an element of a tuple is in this case an attribute of an entity) Ex. (id:3,firstname:"pieter",lastname:"lems").
 - Keys </br>
   There are 2 types of keys:
   - a Primary key which is a set of attributes of which the values are unique in eacht tuple. Ex. (id)
   - a Candidate key which is the smallest set of attributes that form a superkey ( a superkey is a set of keys that uniquely define an entity). For example, if a table has the primarykeys: id firstname lastname, the candidate key can be either (id,firstname) or (id,lastname) or (firstname,lastname).

SQL </br>
Is a language that declares the WHAT and not the HOW.
The language consist of four categories.

The Data Definition Language (DDL) is used to create relations (tables).

Data Manipulation Language (DML) is used to insert,modify and extract data from relations (tables).

Data Control Language (DCL) is used to grant controle to tables,views and databases.

Transaction Control language (TCL) is used to create transactions and control them.

{examples will be implented later}

Normalization </br>
The main reason normalization is used is because it improves the way the database is designed. It is the process of converting the tables of a database into other tables in some normal form( will be explained later). Normalization uses decomposition to eliminate anomalies and redundancy. This is neccesary since it wil:
- minimze te storage space used by relations </br>
  When you join two separate tables you use less storage space then putting everything in the same table. </br>
  In the following image you can see an example of a datatable where some data is redundant.

![Redundancy](https://user-images.githubusercontent.com/24454699/55897263-b7a59f80-5baf-11e9-8113-d4cc92f25f9f.png)


- eliminate anomalies in a database (redundancy | overbodigheden)
  When updating a database which has anomalies there will be null values needed. 
  When deleting a database which has anomalies there will be more info removed than needed.
  When modifying a database which has anomalies you have to modify every tuple by hand because it will not reflect the modification in al the tuples.
  In the following image you can see an example where anomalies have been removed by splitting the table in 2 separate tables.

![No_anomalies](https://user-images.githubusercontent.com/24454699/55897471-166b1900-5bb0-11e9-91db-366cebb43855.png)

- eliminate spurious tuples
  spurious tuples are created when joining 2 tables that are not designed correctly. Normalization makes sure that the decomposition doesn't create spurious tuples. </br>
  In the following image you can see an example of a combined datatable where spurious tuples are created. Everything under the dotted lines are spurious tuples.
  ![Spurious_tuples](https://user-images.githubusercontent.com/24454699/55897454-0eab7480-5bb0-11e9-8168-784bc76ae708.png)

Normal forms </br>
They are properties that a relation must satisfy. You can devide the term normal forms in 2 different kinds of forms:
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
