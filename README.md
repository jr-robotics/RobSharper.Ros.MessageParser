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
```csharp
var descriptor = new MessageParser(File.ReadAllText(filePath)).Parse();
```
or
```csharp
MessageDescriptor descriptor;
            
using (var file = File.OpenRead(filePath))
{
    var parser = new MessageParser(file)
    descriptor = parser.Parse();
}
```

**Parsing a service file**
```csharp
var descriptor = new ServiceParser(File.ReadAllText(filePath)).Parse();
```
or
```csharp
ServiceDescriptor descriptor;
            
using (var file = File.OpenRead(filePath))
{
    var parser = new ServiceParser(file);
    descriptor = parser.Parse();
}
```

**Parsing an action file**
```csharp
var descriptor = new ActionParser(File.ReadAllText(filePath)).Parse();
```
or
```csharp
ActionDescriptor descriptor;
            
using (var file = File.OpenRead(filePath))
{
    var parser = new ActionParser(file);
    descriptor = parser.Parse();
}
```


What you get from the parsers is a either a `MessageDescriptor`, `ServiceDescriptor` or a `ActionDescriptor`
representing the structure of the ROS message file. You can then operate on these message structures.

Have a look on the UML diagram below for a detailed description.

![Message Parsers UML diagram](assets/ros-message-parser-descriptors.png)


#### Intercepting descriptor creation

You can intercept the descriptor creation by creating a class which implements `Joanneum.Robotics.Ros.MessageParser.IRosMessageVisitorListener`.
This allows you to implement the following methods used in the object tree creation:

* `void OnVisitRosMessage(MessageDescriptor messageDescriptor)`
* `void OnVisitRosService(ServiceDescriptor serviceDescriptor)`
* `void OnVisitRosAction(ActionDescriptor actionDescriptor)`
* `void OnVisitFieldDeclaration(FieldDescriptor fieldDescriptor)`
* `void OnVisitConstantDeclaration(ConstantDescriptor constDescriptor)`
* `void OnVisitComment(string comment)`
* `void OnVisitIdentifier(string identifier)`
* `void OnVisitRosType(RosTypeInfo typeInfo)`
* `void OnVisitPrimitiveType(PrimitiveTypeInfo typeInfoDescriptor)`
* `void OnVisitArrayType(ArrayTypeInfo arrayTypeInfo)`
* `void OnVisitRosbagInput(RosbagMessageDefinitionDescriptor rosbag)`
* `void OnVisitRosbagNestedType(NestedTypeDescriptor descriptor);`

You can then pass this listener to the `Parse(IRosMessageVisitorListener listener)` method of the Parser.


### Create your own low level parse tree Visitor or Listener

> Used for low level parse tree processing.

Build your own [ANTLR](https://www.antlr.org/) visitor or listener to process the parse tree. 
Extend `Joanneum.Robotics.Ros.MessageParser.Antlr.RosMessageParserBaseListener` or `Joanneum.Robotics.Ros.MessageParser.Antlr.RosMessageParserBaseVisitor` respectively.

Having ANTLR IDE Support displaying the parse tree will make this expedition much more comfortable. See https://www.antlr.org/tools.html for a list of supported IDE plugins 


## Development

ROS Message Parser for .Net is based on [ANTLRv4](https://www.antlr.org/).