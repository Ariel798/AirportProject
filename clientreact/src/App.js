import { useState } from 'react';
import React from 'react';
import './App.css';

import HomePage from './components/HomePage';
import { Routes, Route } from 'react-router-dom';
import AirportPage from './components/AirportPage';

function App() {

  const [date, SetDate] = useState();

  const HandleHistoryClicked = (date) => {
    SetDate(date);
  }

  return (
    <div className="App">
          <Routes>
            <Route path="/" element={<HomePage parentCallback={HandleHistoryClicked} />}>
              <Route path="/" index element={<HomePage parentCallback={HandleHistoryClicked} />} />
              <Route path="/airport" index element={<AirportPage />} />
              <Route element={<div className="historyStatus">Last updated: {date}</div>} />
            </Route>
            <Route path="/airport" element={<AirportPage />}>
              <Route path="/airport" index element={<AirportPage />} />
            </Route>
          </Routes>
    </div>
  );
}

export default App;
