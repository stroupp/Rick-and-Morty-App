// CharacterPage.js
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import NavBar from '../components/NavBar'; // Import NavBar component
import styles from './CharacterPage.module.css';
import { useDispatch } from 'react-redux';
import { addFavorite } from '../features/favorites/favoritesSlice';

const CharacterPage = () => {
  const { characterId } = useParams();
  const [character, setCharacter] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const dispatch = useDispatch();

  useEffect(() => {
    const fetchCharacter = async () => {
      try {
        setLoading(true);
        const response = await axios.get(`https://rickandmortyapi.com/api/character/${characterId}`);
        setCharacter(response.data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchCharacter();
  }, [characterId]);

  const handleAddToFavorites = () => {
    dispatch(addFavorite(character));
  };

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;
  if (!character) return <div>No character found.</div>;

  return (
    <>
      <NavBar /> {/* NavBar component added */}
      <div className={styles.characterContainer}>
        <h1>{character.name}</h1>
        <div className={styles.characterDetails}>
          <img src={character.image} alt={character.name} className={styles.characterImage} />
          <div className={styles.characterInfo}>
            <p>Status: {character.status}</p>
            <p>Species: {character.species}</p>
            <p>Gender: {character.gender}</p>
            <p>Origin: {character.origin?.name}</p>
            <p>Last Known Location: {character.location?.name}</p>
            {/* Add more details as needed */}
          </div>
        </div>
        <button onClick={handleAddToFavorites} className={styles.favoriteButton}>
          Add to Favorites
        </button>
      </div>
    </>
  );
};

export default CharacterPage;
