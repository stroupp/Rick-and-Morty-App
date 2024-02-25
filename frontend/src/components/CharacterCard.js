// CharacterCard.js
import React from 'react';
import { Link } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { removeFavorite } from '../features/favorites/favoritesSlice'; 
import styles from './CharacterCard.module.css';

const CharacterCard = ({ character, showRemoveButton = false, onRemove }) => {
  const dispatch = useDispatch();

  const handleRemoveFavorite = () => {
    if (onRemove) {
      onRemove();
    } else {
      dispatch(removeFavorite(character.id));
    }
  };

  return (
    <div className={styles.card}>
      <Link to={`/character/${character.id}`} className={styles.cardLink}>
        <img src={character.image} alt={character.name} className={styles.cardImage} />
        <div className={styles.cardInfo}>
          <h3 className={styles.cardTitle}>{character.name}</h3>
          <p>Status: {character.status}</p>
          <p>Species: {character.species}</p>
        </div>
      </Link>
      {showRemoveButton && (
        <button onClick={() => onRemove(character.id)} className={styles.removeButton}>Remove</button>
      )}
    </div>
  );
};

export default CharacterCard;
