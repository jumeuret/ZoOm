# SAE Développement d'une application

## Code :

### ZoOm (Vues)

#### Création des pages :

##### Users Controls

* [X] Carte ( coin ajusté )
* [X] Résumé animal ( nom + espèce + photo )
* [] Soigneur + Directeur 
- [X] UC_Soigneurs ( horloge + évênements + cases à chocher )
- [X] UC_Déconnexion
- [X] Plus dans rectangle
* [] Actualisation ( espaces écritures pour nourrissage, nettoyage, sante, poids, taille )
* [] Création ( espaces écritures + ajout images )
* [] Modification ( especes écitures )
* [X] Recherche ( sans plus )
* [X] Résultats des recherches
* [] Historique

##### Autres

* [X] Carte ( prends tout l'écran + bouton fermeture )
* [X] Message d'erreur ( mot de passe incorect )
* [X] Splashcreen 

#### Liaisons des pages :

* [X] Message d'erreur
* [] UC
* [] Boutons
* [] Recherche fonctionnelle
* [X] Vérification mot de passe
* [X] Afficher mot de passe incorrect que si utilisateur clique sur se connecter
* [X] Enlever plus rectangle dans page visiteur

#### Binding

* [X] UC_Animal
* [X] ComboBox Especes
* [X] Affichage Animal sélectionné dans liste
* [X] Particularités
* [X] Historique

#### Ressources :

* [] Créations de ressources
* [] Déterminer visuel final

### Codage

* [X] Apparition du Splashcreen
* [X] Pertinence de la classe Particularités plutôt que des string
* [X] Rajout attribut Enclos dans classe espèce
* [X] Rajouts attributs nourrissage, nettoyage, santé
* [X] Rajout fonction ActualiserAnimal()
* [X] Rajout historique pour taille et poids
* [X] Remplacement de la liste déroulante espèce par une liste d'espèce ( donne les animaux via la recherche )
* [] Historique

### Tests

* [X] Tests qui ne marchent pas
* [X] Test_Manager 
* [X] Test_Stub
* [X] Test_DataContract
* [X] Test Espece.enclos
* [X] Test Animal.nourissage / nettoyage / sante
* [X] Test Animal.Taille / Poids
* [] CI 
* [] Test_IPersistanceManager ( Bonus )

## Documentation :

### Vérifications :

* [] Diagramme paquetage
* [] Diagramme séquence
* [] Diagramme classes (2)
* [] Description Architecture
* [X] Test fonctionnement Persistance
* [] Script vidéo présentation

## Final :

* [] Documentation du code + nettoyage + rangement ( rangement de ZoOm )
* [] Renommage fonctions déplacement ( Button_Click_1 etc / majuscules dans titres fonction + classes )
* [] Génération Doxyfile
* [] Déploiement
* [] Vidéo ( création requin dormeur mexicain habitat = rivières )


## Questions :

* LINQ [sur 1 point] ?
* Tests Fonctionnels / Unitaires
* CI
* Event property change sur manager dans diagramme classes ?
* classe event dans PageConnexion dans diagramme classes ?



## Problèmes

* Tests unitaires / fonctionnels
* Binding listes déroulantes
* Binding enum
* CI


# Final

## Premièrement

* Choisir visuel final ( couleurs )
* Vérifier le script
* Déployer l'application

## Deuxièmement

* Tourner la vidéo (A)
* Répartiction du script
* Enregistrement voix off
* "Montage"
* Changer mot de passe Directeur
* Renommage fonctions déplacement ( Button_Click_1 etc / majuscules dans titres fonction + classes )
* Documentation du code 
* Rangement de ZoOm dans des dossiers
* Génération documentation Doxygen
* Diagramme de classes

## Dernièrement

### Vérifications :

* [] Diagramme paquetage
* [] Diagramme classes (2)
* [] Description Architecture
* [] Diagramme séquence
* [] Doc Doxygen

### Mise au propre

* [] Diagramme paquetage
* [] Diagramme classes (2)
* [] Description Architecture
* [] Diagramme séquence
* [] Push final sur Master