// Import modules
const jsonServer = require('json-server');
const server = jsonServer.create();
const router = jsonServer.router('db.json');
const middlewares = jsonServer.defaults();
const bodyParser = require('body-parser');

// Use middlewares
server.use(middlewares);
server.use(bodyParser.json());

// Authenticate endpoint
server.post('/authenticate', (req, res) => {
  const { username, password } = req.body;
  const user = router.db.get('users').find({ username, password }).value();

  if (user) {
    res.json({ token: user.token });
  } else {
    res.status(401).json({ error: 'Invalid credentials' });
  }
});

// Register endpoint
server.post('/register', (req, res) => {
  const { username, password, name } = req.body;
  const existingUser = router.db.get('users').find({ username }).value();

  if (existingUser) {
    return res.status(400).json({ error: 'Username already exists' });
  }

  const newUser = {
    id: Date.now(),
    username,
    password,
    name,
    token: `token${Date.now()}`
  };

  router.db.get('users').push(newUser).write();
  res.json({ token: newUser.token });
});

// Start the server
server.use(router);
server.listen(8000, () => {
  console.log('JSON Server is running on port 8000');
});
