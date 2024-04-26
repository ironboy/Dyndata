const port = process.env.PORT || 3035;
const path = require('path');
const express = require('express');
const app = express();
app.use(express.static('www'));
app.get('/README.md', (req, res) =>
  res.sendFile(path.join(__dirname, '..', 'README.md')));
app.listen(port, () => console.log('Listening on http://localhost:' + port));