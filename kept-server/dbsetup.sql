-- CREATE TABLE profiles (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )

--   CREATE TABLE keepstable (
--     id INT NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(1000) NOT NULL,
--     img VARCHAR(255) NOT NULL,
--     views INT NOT NULL,
--     keeps INT NOT NULL,
--     shares INT NOT NULL,
--     tags VARCHAR(255),
--       PRIMARY KEY (id),
--       FOREIGN KEY (creatorId)
--       REFERENCES profiles(id)
--       ON DELETE CASCADE
-- )



    -- CREATE TABLE vaults (
    --     id INT NOT NULL AUTO_INCREMENT,
    --     name VARCHAR(255) NOT NULL,
    --     creatorId VARCHAR(255) NOT NULL,
    --     isPrivate TINYINT NOT NULL,
    --     description VARCHAR(255) NOT NULL,
    --     PRIMARY KEY (id),
    --         FOREIGN KEY (creatorId)
    --         REFERENCES profiles(id)
    --         ON DELETE CASCADE
    -- )

  -- CREATE TABLE vaultKeeps (
  --   id INT NOT NULL AUTO_INCREMENT,
  --   vaultId INT NOT NULL,
  --   keepId INT NOT NULL,
  --   creatorId VARCHAR(255) NOT NULL,
  --     PRIMARY KEY (id),
    
  --     FOREIGN KEY(vaultId)
  --     REFERENCES vaults (id)
  --     ON DELETE CASCADE,

  --     FOREIGN KEY(keepId)
  --     REFERENCES keepstable (id)
  --     ON DELETE CASCADE,
    
  --     FOREIGN KEY(creatorId)
  --     REFERENCES profiles (id)
  --     ON DELETE CASCADE

  -- )