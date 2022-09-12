# Pi Setup

My custom [Docker](https://www.docker.com/)-centered setup for my Raspberry Pi.

The goal of this project is to provide a LAN media streaming server, featuring a web frontend, and media streaming over FTP (designed to work with [VLC](https://www.videolan.org), both for desktop and VLC's mobile apps).

VLC and FTP was chosen for streaming as this approach supports media with subtitles.

## Site

An ASP.NET Core website, which acts as the frontend for the media server.

Frontend libraries, primarily [Bootstrap](https://getbootstrap.com/) and a few default ASP.NET MVC dependencies, are automatically downloaded using [LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/?view=aspnetcore-6.0) during the dockerfile's build process. Bootstrap's source Sass files are then compiled alongside the site's own `.scss` files, into a single `.css` file.

## FTP Server

A simple FTP server, using [ProFTPD](http://www.proftpd.org/) running in an [Alpine Linux](https://www.alpinelinux.org/) container, which allows anonymous read-only file access as well as read-write authenticated file access.

Alpine Linux was chosen due to its small size and fast application installation times.

## Pi-hole

A standard [Pi-hole](https://pi-hole.net/) container, to help remove advertisements from the network. Devices on the network can set their primary DNS to point to the Raspberry Pi's local IP address.

The Pi-hole also specifies custom DNS domain mappings, to allow for the site to be accessed via a domain rather than having to use an IP address.
