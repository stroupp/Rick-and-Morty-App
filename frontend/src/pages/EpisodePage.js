// EpisodePage.js
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchEpisodeDetails } from '../api/rickAndMortyApi';
import NavBar from '../components/NavBar'; 
import CharacterCard from '../components/CharacterCard';
import styles from './EpisodePage.module.css';

const EpisodePage = () => {
  const { id } = useParams();
  const [episodeData, setEpisodeData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const getEpisodeDetails = async () => {
      try {
        setLoading(true);
        const data = await fetchEpisodeDetails(id);
        setEpisodeData(data);
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    getEpisodeDetails();
  }, [id]);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;
  
  return (
    <>
      <NavBar /> {}
      <div className={styles.episodeContainer}>
        <h1 className={styles.episodeTitle}>{"Episode Name: " +  episodeData?.name}</h1>
        <p className={styles.episodeAirDate}><strong>Air date:</strong> {episodeData?.air_date}</p>
        <div className={styles.characterList}>
          {episodeData?.characters.map((character) => (
            <CharacterCard key={character.id} character={character} />
          ))}
        </div>
      </div>
    </>
  );
};

export default EpisodePage;
