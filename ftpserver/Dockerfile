FROM alpine:latest
ARG FTPSERVER_USERNAME \
    FTPSERVER_PASSWORD
COPY ./ftpserver/proftpd.conf /etc/proftpd/proftpd.conf
COPY ./ftpserver/setup.sh /setup.sh
RUN sh /setup.sh
ENTRYPOINT proftpd -n
