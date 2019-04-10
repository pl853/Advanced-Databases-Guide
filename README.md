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
   Are used to uniquely identify an entity, it can be a single or a set of attributes that define an entity. There are 2 types of keys:
   - Primary keys are the keys chosen for a relation amongs candidate keys (candidate keys will be explained later).
   - Foreign keys are a set of attributes in one relation (table) which is a primary key in another relation (table) </br>
    Ex 1. An id for a starship. In this example starships can't have the same key. </br>
    Ex 2. A firstname and a lastname for a person combined. In this case a people can't have the same combination of firstname and lastname. </br>
    In the image below there is an example of the 2 types of keys. In this case shipid is a foreign key to ships.</br>


![ex+keys](https://user-images.githubusercontent.com/24454699/55898683-a8742100-5bb2-11e9-812b-1979858118cc.png)
</br>

 - Weak entities </br>
   Are attributes that don't have to be or are not unique. Ex. the speed of a starship. Multiple starships can have te same speed.</br>
   </br>
In the image below you can see an example of a datatable. In this datatable Ships is the enity. The attributes are: id, name ,shields, pilot, armour, integrity. The set of values at the bottom of the image is an example of a tuple of data (term tuple will be explained later).</br>
 
![ex_entity_attr_tuple](https://user-images.githubusercontent.com/24454699/55898343-e6bd1080-5bb1-11e9-8c43-94c8c137ab58.png)
</br>
 

Relational model </br>
A model halfway between a conceptual model and the physical model, it contains an abstraction of physical elements.
 - Relation </br>
   In a relational model a relation is a collection of tuples (an element of a tuple is in this case an attribute of an entity) Ex. (id:3,firstname:"pieter",lastname:"lems").
 - Keys </br>
   There are 2 types of keys:
   - a Primary key which is a set of attributes of which the values are unique in eacht tuple. Ex. (id)
   - a Candidate key which is the smallest set of attributes that form a superkey ( a superkey is a set of keys that uniquely define an entity). For example, if a table has the primarykeys: id firstname lastname, the candidate key can be either (id,firstname) or (id,lastname).

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

Functional dependencies </br>
Are dependencies that are defined by the designer. They can't be infered by reading data from the database table, instead they should be read in the documentation of the database. Only if there is no documentation provided with the database, you can try to infer functional dependencies from the data.

Normal forms </br>
They are properties that a relation must satisfy. You can devide the term normal forms in 2 different kinds of forms:
- Historical definitions </br>
  The original definitions defined by the code, taking into account only the primary key.
- Refined definitions </br>
  A refinement of the normal forms that also takes the candidate keys into account.

The first normal form [1NF] </br> will be automaticly given by the relational model unless the ERD is not translated correctly in the relational model. All your relations should be 1NF.
You can see if a table is in 1NF by checking wether a row has multiple values for one attribute. If this is the case the table is not in 1NF. </br>
The image below is an example of a table that is not 1NF, this is because the attribute PNUMBER is not unique in the datatable.

![No_1NF](https://user-images.githubusercontent.com/24454699/55897466-1408bf00-5bb0-11e9-811d-d90f80e118f0.png)

The second normal form [2NF] </br>
A table is in 2NF if every attribute that is not part of the key depends on the whole primary key.</br>
For example the table in the image below is not in 2NF because PNAME and PLOCATION only depend on PNUMBER and not on SSN and PNUMBER (which togheter is the whole key).</br> 

![not_2NF](https://user-images.githubusercontent.com/24454699/55899624-d2c6de00-5bb4-11e9-9a04-b41c10409bd8.png)
</br>

AN USEFULL TRICK TO CHECK IF A TABLE IS IN 2NF:</br>
If the primary key of a table is made of only one attribute the table is always 2NF. This is because there is no functional dependency where the left side is a part of the primary key.

The third normal form </br>
In this form a transitive dependency needs to be defined. A functional dependency is transive if there is a set of attributes which is neither a candidate key nor a subset of any key. </br>
In the image below you see an example of a transive dependency. </br>

![transive_dependency](https://user-images.githubusercontent.com/24454699/55901759-88942b80-5bb9-11e9-9594-6f75ec82d20d.png)

As you can see the functional dependency SSN -> {DNAME,DMGRSSN} is transitive because SSN -> DNUMBER and DNUMBER -> {DNAME,DMGRSSN} are valid functional dependencies and is not a candidate key nor a subset of any key.


{examples will be implented later}


Normalization on candidate keys </br>

Normalization Algorithms </br>
Below we will learn some algorithms for normalizing tables. The algorithms are:
- From unnormalized to 1NF </br>
  
  First we have to find an attribute which is non-atomic (non-atomic means that the attribute contains multiple values)</br>
  The image below contains an non-atomic attribute which is called PROJS.</br>
  
  ![table_withnonatomic](https://user-images.githubusercontent.com/24454699/55904905-6d78ea00-5bc0-11e9-93cd-5e5f639fff1e.png)
  </br>
  
  
  The attribute PROJS is made up by the sub-attributes PNUMBER and HOURS The other attributes , SSN and ENAME, are atomic atributes.
- From 1NF to 2NF
- from 2NF to 3NF

