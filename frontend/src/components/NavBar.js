import React from 'react';
import { Link } from 'react-router-dom';
import styles from './NavBar.module.css';

const NavBar = () => {
  return (
    <nav className={styles.navBar}>
      <h1 className={styles.title}>Rick and Morty</h1>
      <div>
        <Link to="/" className={styles.navLink}>Episodes</Link>
        <Link to="/favorites" className={styles.navLink}>Favorites</Link>
      </div>
    </nav>
  );
};

export default NavBar;
