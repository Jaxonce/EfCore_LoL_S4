[![Build Status](https://codefirst.iut.uca.fr/api/badges/maxence.lanone/EfCore_LoL_S4/status.svg)](https://codefirst.iut.uca.fr/maxence.lanone/EfCore_LoL_S4)
[![Quality Gate Status](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=EfCore_Lol_S4&metric=alert_status&token=bddb7be5fabeea33ecbe67cb7507d80b3690df07)](https://codefirst.iut.uca.fr/sonar/dashboard?id=EfCore_Lol_S4)
[![Coverage](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=EfCore_Lol_S4&metric=coverage&token=bddb7be5fabeea33ecbe67cb7507d80b3690df07)](https://codefirst.iut.uca.fr/sonar/dashboard?id=EfCore_Lol_S4)
[![Maintainability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=EfCore_Lol_S4&metric=sqale_rating&token=bddb7be5fabeea33ecbe67cb7507d80b3690df07)](https://codefirst.iut.uca.fr/sonar/dashboard?id=EfCore_Lol_S4)

# League Of Legends

Ce dépot réuni plusieurs choses :

## Code

- Une api qui permet de faire des requetes CRUD afin de récuperer les différentes données stocker sur une base de donnée.
- Un ORM réalisé avec EntityFramework mettant représentant le célèbre jeu LeagueOfLegends.
- Une application MAUI permettant de mettre en scène les données de la base.

## Documention

- Une documentation de l'api avec les différentes requetes possible.
- Plusieurs schémas dont l'architechture de l'ORM et le lien entre les différents éléments (ORM, API, Application mobile).

## Avancement des projets

# :zap: Consommation  et Développement de services

> * :white_check_mark: La mise en place de toutes les opérations CRUD est terminée.
> * :white_check_mark: Une API RESTful a été mise en place en respectant les règles de routage et en utilisant les bons codes de statut.
> * :construction: La version de l'API a été gérée de manière appropriée.
> * :white_check_mark: Les logs ont été implémentés.
> * :construction: Les tests unitaires sont en cours de réalisation.
> * :construction: La création du client MAUI et sa liaison avec l'API sont en cours de réalisation.
> * :construction: La liaison avec la base de données est opérationnelle.
> * :construction: Le filtrage et la pagination des données ont été implémentés.
> * :white_check_mark: Le code est de qualité grâce à l'utilisation de SonarQube.
> * :white_check_mark: L'API a été dockerisée et hébergée sur CodeFirst.
> * :construction: Sécurité

`Note : Le client MAUI a été mis en place mais il n'utilise que le stub actuellement et n'est pas relié à l'api.`


---


# :zap: Entity Framework :

Voici l'état des différentes tâches liées à Entity Framework :

> * :white_check_mark: **Exercice 1** : Une base de données a été créée avec une table pour les champions, et des requêtes CRUD ont été implémentées, ainsi que du filtrage et de la pagination. Le client console n'a pas été réalisé pour cet exercice par manque de temps.
> * :white_check_mark: **Exercice 2** : Des tests unitaires ont été écrits et une base de données a été simulée à l'aide de SQLiteInMemory.
> * :white_check_mark: **Exercice 3** : Entity Framework a été déployé et les tests ont été effectués via Code#0.
> * :white_check_mark: **Exercice 4**: Les tables pour les runes et les skins ont été implémentées (sans les relations).
> * :white_check_mark: **Exercice 5** : Une relation OneToMany a été établie entre les champions et les skins.
> * :white_check_mark: **Exercice 6** : Une relation ManyToMany a été établie entre les champions, les rune pages et les runes.
> * :construction: **Exercice 7** : Le mapping entre le modèle et l'entité a été réalisé pour améliorer la qualité du code.
> * :construction: **Exercice 8** : La mise en place du pattern UnitOfWork n'a pas pu être implémentée par manque de temps.
--- 


# Lancer le projet

Cette partie est réalisé avec un mac, toutes les manipulations qui vont suivre seront donc réalisé avec la dernière version de Visual Studio pour mac.

## Android

:construction:

## IOS
 

### 1 - Cloner le dépot 

Ouvrer Visual Studio Pour Mac, cloner le depot a l'aide du lien suivant:

    https://codefirst.iut.uca.fr/git/maxence.lanone/EfCore_LoL_S4.git


### 3 - Configurer le démarrage du projet 

> clique droit sur le projet dans l'explorateur de solution > Set Startup Projects  

Et selectionner soit LolApp + WebApiLol, soit ConsoleTests + WebApiLol.
### 4 - Lancement du projet

Vous pouvez alors lancer le projet grâce à la flèche verte, bonne navigation !

# Documention

Rendez vous sur la partie wiki du projet pour accéder aux différents diagrammes ainsi qu'à la documention de l'api.

# Réalisation

Projet réalisé par Maxence Lanone, élève en PM3.