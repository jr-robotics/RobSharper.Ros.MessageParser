# ROS Message Parser for .Net
> Hanlde ROS message files with ease

ROS Message Parser allows you to parse ROS message/service/action files.

You can either use one built in Parser for
* Messages (*.msg)
* Services (*.srv)
* Actions (*.action)

or build your own visitors or listeners on top of the generated parse tree.


## Installation

ROS Message Parser for .Net is available as NuGet Package. 

**TODO** Publish as nuget.

## Usage


### Built in Parsers

> Use the built in parsers if you want to get a structured representation of a ROS message.

**Parsing a message file**
```C#
var descriptor = MessageParser.Parse(File.ReadAllText(filePath));
```

```C#
MessageDescriptor descriptor;
            
using (var file = File.OpenRead(filePath))
{
    descriptor = MessageParser.Parse(file);
}
```

**Parsing a service file**
```C#
var descriptor = ServiceParser.Parse(File.ReadAllText(filePath));
```

```C#
ServiceDescriptor descriptor;
            
using (var file = File.OpenRead(filePath))
{
    descriptor = ServiceParser.Parse(file);
}
```

**Parsing an action file**
```C#
var descriptor = ActionParser.Parse(File.ReadAllText(filePath));
```

```C#
ActionDescriptor descriptor;
            
using (var file = File.OpenRead(filePath))
{
    descriptor = ActionParser.Parse(file);
}
```

What you get from the parsers is a either a ```MessageDescriptor```, ```ServiceDescriptor``` or a ```ActionDescriptor```
representing the structure of the ROS message file.

Have a look on the UML diagram below for a detailed description.

![Message Parsers UML diagram](assets/ros-message-parser-descriptors.png)


### Build your own Visitor

> Use this if you want to directly operate on the generated parse tree.

**TODO** 




## Development

ROS Message Parser for .Net is based on [ANTLRv4](https://www.antlr.org/).