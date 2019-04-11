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
- minimize te storage space used by relations </br>
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
  spurious tuples are created when joining 2 tables that are not designed correctly, this will create more tuples than were in the original tables. These redundant tuples are called spurious tuples. Normalization makes sure that the decomposition doesn't create spurious tuples. </br>
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
You can see if a table is in 1NF by checking wether a row has multiple values for one attribute. If this is the case the table is NOT in 1NF. </br>
The image below is an example of a table that is not 1NF, this is because the attribute PNUMBER is not unique in the datatable.

![No_1NF](https://user-images.githubusercontent.com/24454699/55897466-1408bf00-5bb0-11e9-811d-d90f80e118f0.png)

The second normal form [2NF] </br>
A table is in 2NF if every attribute that is NOT part of the key depends on the whole primary key.</br>
For example the table in the image below is NOT in 2NF because PNAME and PLOCATION only depend on PNUMBER and not on SSN and PNUMBER (which togheter is the whole key).</br> 

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
  To understand the unnormalized to 1NF algorith you first have to know the definitions of the following terms:
  - Non-atomic attributes </br>
    A non-atomic attibute , also called a composite attribute, is an attribute that consist out of multiple attributes.
    In the image below PROJS is a non-atomic attribute that consists out of the attributes PNUMBER and HOURS. </br>
    ![non-atomic_att](https://user-images.githubusercontent.com/24454699/55906562-12e18d00-5bc4-11e9-8c8a-dfbb2a3b5c27.png)
    </br>
  - Sub-attributes </br>
    A sub-attibute is an attribute that is derives from an non-atomic attribute. In the image above PNUMBER and HOURS are both sub-attributes of PROJS.
  
  Now that you know the definitions of the terms mentioned above we can create the algorithm. 
  
  First we have to find an non-atomic attribute.
  The image below contains an non-atomic attribute which is called PROJS.</br>
  
  ![table_withnonatomic](https://user-images.githubusercontent.com/24454699/55904905-6d78ea00-5bc0-11e9-93cd-5e5f639fff1e.png)
  </br>
  
  The attribute PROJS is made up by the sub-attributes PNUMBER and HOURS. The other attributes , SSN and ENAME, are atomic atributes.</br>
  After you located the non-atomic attribute you create a new table , which in this case is called EMP_PROJ1, containing the primary key (SSN in this case) and the atomic attribute ENAME. </br>
  Then you create a table called EMP_PROJ2 which contains the primarykey (SSN) and the two sub-attributes of the non-atomic attribute(PROJS) which are PNUMBER and HOURS. In the new table we just created (EMP_PROJ2) the primary key is the combination of (SSN,PNUMBER) because the values of PNUMBER are unique which is a neccesity for a primary key. SSN is a foreign key to EMP_PROJ1. </br>
  
  But what if there are multiple non-atomic attributes? </br>
  If thats the case you should just repeat the steps for all non-atomic attributes.

- From 1NF to 2NF</br>
  To understand this algorithm you first have to understand what the reason is that the 2NF is broken. To recap this go to the Normal forms section. </br>
  It's also smart to recap the definition of functional dependency.

  First we have to  an attribute that is:
  - Not a key or part of the key
  - Is functionally dependent on only a part of the key. NOT THE WHOLE KEY!

  In the image below you see a table in 2NF. The attributes that "break" the 2NF are FD2 (functional dependency 2) and FD3 (functional dependency 3).</br>
  ![1NF2NF](https://user-images.githubusercontent.com/24454699/55910542-2b56a500-5bce-11e9-8704-f66a4ca18ada.png)
  </br>
    PLEASE UNDERSTAND THE FOLLOWING:
  - That 2NF is broken by an attribute that is not part of the key and is only functionally dependent on a part of the key!
  - The reason for FD2 breaking the 2NF is because ENAME only depends on SSN and not on PNUMBER.
  - The reason for FD3 breaking the 2NF is because PNAME and PLOCATION only depend on PNUMBER.
  - The reason for FD1 NOT breaking the 2NF is because HOURS depends on both of the key attributes (SSN PNUMBER)

  After you found an attribute which satisfys the characteristics mentionend above you remove the attribute from the table (EMP_PROJ).</br> 
  The combination of attributes that are left will create the table EP1 which represents FD1. (see image below) </br>
  ![ep1](https://user-images.githubusercontent.com/24454699/55913667-acb13600-5bd4-11e9-86f2-e3c7d0ef90f3.png)
  </br>

  Then you create a table called EP2 containing SSN (the primary key left) with the attribute that depends on it (ENAME). This table represents FD2 (see image below) </br>
  ![ep1](https://user-images.githubusercontent.com/24454699/55913231-abcbd480-5bd3-11e9-962f-fe8a01097717.png)
  </br>
  After that your create a table called EP3 which represent FD3. This table contains PNUMBER and the attributes that depend on it. (PNAME and PLOCATION) (see image below) </br>
  ![ep3](https://user-images.githubusercontent.com/24454699/55913384-10872f00-5bd4-11e9-8bd0-704b5eaa5e5d.png)
  </br>

  The final result is shown in the image below. </br>
  ![ep1_ep2_ep3](https://user-images.githubusercontent.com/24454699/55913451-33194800-5bd4-11e9-9886-4b068a674f4b.png)
  </br>


  
- from 2NF to 3NF

ACID
Is an abriviaton of Atomic Consistency Isolation Durability. It is a concept referring to a database system’s four transaction properties: atomicity, consistency, isolation and durability. Below you find an explanation of each of the four propperties:
- Atomicity
  A database follows the all or nothing rule, i.e., the database considers all transaction operations as one whole unit or atom. That means when a database processes a transaction, it is either fully completed or not executed at all. A transaction can either commit after completing or abort after executing an action. 
- Consistency
  Ensures that only valid data following all rules and constraints is written in the database. When a transaction results in invalid data, the database reverts to its previous state, which abides by all customary rules and constraints.
- Isolation
  Ensures that transactions are securely and independently processed at the same time without interference, but it does not ensure the order of transactions. For example, user A withdraws $100 and user B withdraws $250 from user Z’s account, which has a balance of $1000. Since both A and B draw from Z’s account, one of the users is required to wait until the other user transaction is completed, avoiding inconsistent data. If B is required to wait, then B must wait until A’s transaction is completed, and Z’s account balance changes to $900. Now, B can withdraw $250 from this $900 balance.

Transaction </br>
A transaction is a logical unit(querie) that is independentlu exectuted for data retrieval or updates. In the image below you can see multiple transaction queries. </br>
![transaction](https://user-images.githubusercontent.com/24454699/55954072-44526b00-5c4d-11e9-9af9-52e9da1709f2.png) 
</br>
Let's take the image above. We should write down what happends in the image.
- The name of the ship called Oleg will be changed to Alpha.
- A savepoint called my_savepoint is created to which the database can roll back to.</br>
- The integrety of the ship called Alpha is set to 30.
  The step mentioned above will cause problems since there is no ship in the database that has the name Alpha, YET. Because of this we roll back to the savepoint (my_savepoint).
- The integrety of the ship called Beta is improved by 10.
- Then we commit the changes to the database. (the changes will be saved in the database)

We can also write down transactions in a simpler way. This is done in the image below.</br>

![simplefied_trnas](https://user-images.githubusercontent.com/24454699/55954150-7a8fea80-5c4d-11e9-9b6f-00d4f048feb5.png)
</br>

In transaction 1 (T1) , 10 energy will be subtracted from the ships energy (ship1.energy -10) and 10 shield will be added to the ships shield(ship1.shield + 10). After each transaction the changes will be committed (saved in the database). </br>

For the transactions above you can create a transaction schedule which displays the order of the transactions in a better way. You can also create a DBMS (Atomic Consistency Isolation Durability) interleaved schedule, which displays what happends in an even more detailed way. (see images below) </br>
</br>
The transaction schedule of possibility 1: </br>
![poss1](https://user-images.githubusercontent.com/24454699/55955319-9ba60a80-5c50-11e9-800a-8482979965ca.png)
</br>
The interleaved schedule of possibility 1:</br>
![interleaved1](https://user-images.githubusercontent.com/24454699/55955905-30f5ce80-5c52-11e9-86ec-8aa50911a3f7.png)
</br>

In the interleaved schedule you can see the letters R which stands for read (reading the data of the value between the brackets which is in this case ship 1 FROM the database and W which stands for write (writing the data TO the value between the brackets which in this case is ship 1). If we take the first part of the transaction T1 (ship1.energy = ship1.energy - 10),  the R(s1) in the schedule means that it reads the value of ship1.energy from the database. W(s1) means that it writes to the value of ship1, in this case thats energy -10. </br>

Lets take practice a scenario where s1.energy = 50 and s2.shields =70, the transactions in schedule 1 will occure are as follows:
- s1.energy = s1.energy - 10.  R(s1) is in this case 50.  W(s1) is in this case 50 - 10 = 40. This part of the transaction is not commited to the database yet so the next time s1.energy is read (R(s1) it's still 50).
- s1.energy = 1.05 * s1.energy. R(s1) is in this case still 50. W(s1) is in this case 1.05 * 50 = 52.5. so at this point s1.energy = 52.5. 
- s2.shield - s2.shields + 10. R(s2) is in this case 70.  W(s2) is in this case 70 + 10 = 80.
- Now the transaction T1 which has the values (52.5, 80) is commited to the database. The values that will be commited are s1.energy = 52.5 and s2.shield = 80. So in the database s1.energy = 52.5 and s2.shield = 80.
- s2.shields = 1.05 * s2.shields. R(s2) is in this case 80 because thats the value in the database. W(s2) is in this case 1.05* 80 = 84.
- Now the transaction T2 which has the values (52.5, 80) is commited to the database again which leaves that database values at s1.energy = 52.5 and s2.shields = 80.

The transaction schedule of possibility 2:</br>
![poss2](https://user-images.githubusercontent.com/24454699/55955353-ba0c0600-5c50-11e9-962d-d0206980e0fb.png)


The interleaved schedule of possibility 2:</br>
![interleaved2](https://user-images.githubusercontent.com/24454699/55955905-30f5ce80-5c52-11e9-86ec-8aa50911a3f7.png)
</br>

Lets take practice a scenario where s1.energy = 50 and s2.shields =70, the transactions in schedule 2 will occure are as follows:
- s1.energy = s1.energy - 10.  R(s1) is in this case 50.  W(s1) is in this case 50 - 10 = 40. This part of the transaction is not commited to the database yet so the next time s1.energy is read (R(s1) it's still 50).
- s1.energy = 1.05 * s1.energy. R(s1) is in this case still 50. W(s1) is in this case 1.05 * 50 = 52.5. so at this point s1.energy = 52.5. 
- s2.shield - 1.05 * s2.shields. R(s2) is in this case 70.  W(s2) is in this case 1.05 * 80 = 73.5.
- Now transaction T2 which has the values (52.5, 73.5) is commited to the database. The values that will be commited are s1.energy = 52.5 and s2.shield = 73.5 . So in the database s1.energy = 52.5 and s2.shield = 73.5.
- s2.shields = s2.shields +10. R(s2) is in this case 73.5 because thats the value in the database. W(s2) is in this case 73.5 + 10  = 83.5.
- Now transaction T1 which has the values (40, 83.5) is commited to the database again which leaves that database values at s1.energy = 40 and s2.shields = 73.5.

The outcome of the two schedules are not equivalent. This means that a problem occured during the transactions.</br>
This can be cause by a af types of problems:
- The different schedules of transactions might ignore operations finalized by other transactions.
  The reason for this are conflits with Read/Write operations.
- A conflict that's caused by the isolation property of transactions.
  The isolation property can cause an anomaly in the database.

There are four possible combinations of Read/Write operations:
- Read/Read </br>
  This combination is always safe because it doesn't alter the data.
- Write / Read </br>
  This combination can cause an issue called Dirty read. In the image below you find an example of a transaction schedule where Dirty read occurs. </br> 
  ![dirtyread](https://user-images.githubusercontent.com/24454699/55960925-4de3cf00-5c5d-11e9-9876-2a529d220811.png)
  </br>
  As you can see T1 reads and writes the energy but does not commit it to the database. Meanwhile T2 also reads the energy and the shields and then writes them.</br>
  The problem here is that the value of the energy of T1 is overwritten by the value of energy from T2.
- Read/Write </br>
  This combiation can cause an issue called unrepeatable reads. In the image below you find an example of a transaction schedule where Unrepeatable read occurs </br>
  ![unrepeat](https://user-images.githubusercontent.com/24454699/55961747-0fe7aa80-5c5f-11e9-9bea-67d2e9c538e7.png)
  </br>
  As you can see T1 first reads s1.energy and then does something with A (Ex. A + 10). Then T2 reads s1.energy aswell, does something with it and commits it. Now in T1 energy is read again but now its getting a different value. </br>
  The problem here is that T1 reads the same value twice but the results are different.
- Write/Write</br>
  This combination can cause an issue called lost update. In the image below you find an example of a transaction schedule where lost update occurs</br>
  ![lostupdate](https://user-images.githubusercontent.com/24454699/55962336-2cd0ad80-5c60-11e9-8c8c-95b5bb557d80.png)
  </br>
  As you can see in the image T2 commits first and then overwrites the changes to the shield made by T1.</br>
  The problem here is that the update made by one of the transactions is lost.

Serializability
Is getting rid of the consquences when a conflict occurs, there will never be a conflict in serial executions. Two schedules are conflict equivalent if you can transform to one another by swapping operations DO NOT conflict. In the image below there is a conlict happening. Do you know what conflict this is? </br>

![DIRTYREAD](https://user-images.githubusercontent.com/24454699/55968244-2ac01c00-5c6b-11e9-99cf-914e03352bda.png)
</br>
If your answer was Dirty read you answered correctly! The reason for the conflict being dirty read is because in T1 a is read en writen and before commiting T1, T2 also reads and writes A. </br>
To make this transition schedule conflict equilvalent to the serial execution The read and write in T1 on B should be performed before the read/write on A in T2.</br>

Conflict serializability is not always possible. 
Locking 
- Strict Two Phase-Locking (2PL)
- Locking on tables
- Phantom update
- Transaction isolation
- Deadlocks
- Deadlock prevention


