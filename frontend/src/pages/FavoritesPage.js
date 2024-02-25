// FavoritesPage.js
import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { removeFavorite } from '../features/favorites/favoritesSlice'; 
import NavBar from '../components/NavBar'; 
import CharacterCard from '../components/CharacterCard'; 
import styles from './FavoritesPage.module.css'; 

const FavoritesPage = () => {
  const favorites = useSelector((state) => state.favorites.characters);
  const dispatch = useDispatch();

  const handleRemove = (characterId) => {

    const character = favorites.find((c) => c.id === characterId);
    if (window.confirm(`Are you sure you want to remove ${character?.name} from favorites?`)) {
      dispatch(removeFavorite(characterId));
    }
  };

  return (
    <>
      <NavBar /> {}
      <div className={styles.favoritesContainer}>
        <h1 className={styles.favoritesTitle}>Favorite Characters</h1>
        <div className={styles.characterList}>
          {favorites.length > 0 ? (
            favorites.map((character) => (
              <CharacterCard
                key={character.id}
                character={character}
                showRemoveButton={true}
                onRemove={() => handleRemove(character.id)} 
              />
            ))
          ) : (
            <p>No favorite characters added.</p>
          )}
        </div>
      </div>
    </>
  );
};

export default FavoritesPage;
