# Unity Quote of the Day (QOTD) Client implementing RFC 865

This is a simple client connecting to a server, receiving data, and displaying it.

- Connects and reads asynchronously, to avoid halting of the game (fps/performance drop)
- Caches one quote in advance, to avoid further waiting
- Implements the [RFC 865 Quote of the Day Protocol](https://datatracker.ietf.org/doc/html/rfc865)

## Usage
- If no server is specified, it will default to "djxmmx.net"
- Hit the wall with the box, by moving it with the arrow keys
- Receive a pre-cached quote
- Repeat

## Environment
Tested on
- Unity 2021.3.7f1
- Windows 10

## Sample Video
[![Link to YouTube Video](https://img.youtube.com/vi/1A-CHKNtaRw/0.jpg)](https://youtu.be/1A-CHKNtaRw)
