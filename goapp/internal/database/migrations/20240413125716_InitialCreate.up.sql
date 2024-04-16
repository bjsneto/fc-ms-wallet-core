CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(36) PRIMARY KEY,
    client_id VARCHAR(36) NOT NULL,
    balance INTEGER NOT NULL,
    created_at TIMESTAMP NOT NULL
);

CREATE TABLE IF NOT EXISTS clients (
    id VARCHAR(36) PRIMARY KEY,
    name TEXT NOT NULL,
    email TEXT NOT NULL,
    created_at TIMESTAMP NOT NULL
);

CREATE TABLE IF NOT EXISTS transactions (
    id VARCHAR(36) PRIMARY KEY,
    account_id_from VARCHAR(36) NOT NULL,
    account_id_to VARCHAR(36) NOT NULL,
    amount INTEGER NOT NULL,
    created_at TIMESTAMP NOT NULL
);

INSERT INTO accounts (id, client_id, balance, created_at) VALUES 
    ('1232b62f-5b34-4b8a-9f7a-1a349390a353', 'ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74', 10, '2024-04-10 22:19:38'),
    ('d95f9fc4-3cf4-49e9-afd9-007da4653f4a', '4cf4c747-8b7e-4520-92bd-431e64b2ab4c', 100000, '2024-04-10 22:19:38');

INSERT INTO clients (id, name, email, created_at) VALUES 
    ('4cf4c747-8b7e-4520-92bd-431e64b2ab4c', 'Belarmino', 'belarmino@mail.com', '2024-04-10 22:19:38'),
    ('ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74', 'Neto', 'neto@mail.com', '2024-04-10 22:19:38');
