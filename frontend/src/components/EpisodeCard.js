import React from 'react';
import { Link } from 'react-router-dom';
import styles from './EpisodeCard.module.css';

const EpisodeCard = ({ episode }) => {
  return (
    <Link to={`/episode/${episode.id}`} className={styles.cardLink}>
      <div className={styles.card}>
        <h3>{episode.name}</h3>
        <p>{episode.air_date}</p>
        {}
      </div>
    </Link>
  );
};

export default EpisodeCard;
