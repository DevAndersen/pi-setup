apk add --no-cache proftpd
addgroup ftpgroup
adduser -D -G ftpgroup $FTPSERVER_USERNAME
echo -e "$FTPSERVER_PASSWORD\n$FTPSERVER_PASSWORD" | passwd $FTPSERVER_USERNAME
mkdir /files /run/proftpd
chown -R $FTPSERVER_USERNAME:ftpgroup /files
