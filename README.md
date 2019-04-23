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

**TODO** Add example project

### Built in Parsers

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



## Development

ROS Message Parser for .Net is based on [ANTLRv4](https://www.antlr.org/).