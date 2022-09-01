# Pi Setup

## FTP Server

A simple FTP server, using [ProFTPD](http://www.proftpd.org/) running in an [Alpine Linux](https://www.alpinelinux.org/) container, which allows anonymous read-only file access as well as read-write authenticated file access.

## Pi-hole

A [Pi-hole](https://pi-hole.net/) container, running with near-default settings. It also specifies custom DNS domain mappings, to make the site more easily accessible.

## Site

Frontend libraries, primarily [Bootstrap](https://getbootstrap.com/) and a few default ASP.NET MVC dependencies, are automatically downloaded using [LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/?view=aspnetcore-6.0).
