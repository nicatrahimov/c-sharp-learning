CREATE TABLE personal_site.Certificate (
                             Id UUID PRIMARY KEY,
                             Title VARCHAR(100) NOT NULL,
                             Issuer VARCHAR(100) NOT NULL,
                             Issued_Date DATE NOT NULL,
                             Expiration_Date DATE
);
