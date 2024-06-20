# Sudoku Project

## Description
Ce projet est une application de Sudoku qui permet aux utilisateurs de jouer à des grilles de Sudoku de différentes tailles (9x9 et 16x16), de gérer les joueurs, de suivre leurs statistiques, et de sauvegarder les données des joueurs.

## Fonctionnalités
- **Jouer au Sudoku** : Choix entre des grilles de 9x9 et de 16x16.
- **Gestion des Joueurs** : Ajouter, sélectionner et consulter les statistiques des joueurs.
- **Affichage des Scores** : Voir les meilleurs temps et le nombre de parties jouées par chaque joueur.
- **Musique d'Ambiance** : Musiques différentes pour le menu et les parties.
- **Aide et Règles** : Affichage des règles du jeu en passant le curseur sur un personnage dans le menu.
- **Validation des Entrées** : Les entrées incorrectes dans la grille deviennent rouges.

## Installation
1. Clonez ce dépôt :
   ```sh
git clone https://github.com/021user/Sudoku-VB.git
   ``
2. Ouvrez le projet dans votre IDE préféré.
3. Assurez-vous que les fichiers de ressources (images et musique) sont accessibles dans le répertoire `src/Resources/`.

## Utilisation
- **Lancer l'Application** : Exécutez le fichier `Menu.vb` pour lancer l'application.
- **Ajouter un Joueur** : Entrez un nouveau nom dans le champ de saisie et appuyez sur `Entrer`.
- **Commencer une Partie** : Sélectionnez un joueur, choisissez la taille de la grille et commencez à jouer.

## Structure des Fichiers
- **Menu.vb** : Interface principale de l'application.
- **Player.vb** : Classe représentant un joueur.
- **PlayerStatisticsForm.vb** : Interface pour afficher les statistiques des joueurs.
- **GameForm.vb** : Interface pour jouer au Sudoku 9x9.
- **GameForm16x16.vb** : Interface pour jouer au Sudoku 16x16.
- **Resources/** : Répertoire contenant les ressources du projet (images, musique).
- **joueur.txt** : Fichier texte pour sauvegarder les données des joueurs.

## Contributions
Les contributions sont les bienvenues ! Veuillez ouvrir une issue pour discuter de ce que vous aimeriez changer.
