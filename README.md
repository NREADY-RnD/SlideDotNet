<h3 align="center">

![SlideDotNet](/resources/readme.png)

</h3>

<h3 align="center">

  [![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
  [![NuGet](https://img.shields.io/nuget/v/SlideDotNet?color=blue)](https://www.nuget.org/packages/SlideDotNet)  

</h3>

SlideDotNet is a fluent wrapper around [Open XML SDK](https://github.com/OfficeDev/Open-XML-SDK) for the processing of PowerPoint files without Microsoft Office installed. It aims to provide an intuitive and user-friendly interface to dealing with the underlying Open XML SDK API.

## Getting Started
You can quickly start work with the library by following steps listed below.

### Prerequisites
* .NET Core 2.2 or above

### Installing
To install SlideDotNet, run the following command in the Package Manager Console:
```
PM> Install-Package SlideDotNet
```

### Usage
```C#
// opens presentation from the file path
var presentation = new PresentationEx(@"c:\test.pptx");

// gets the slides collection
var slides = presentation.Slides; 

// gets number of slides
var numSlides = slides.Count(); 

// gets the shapes collection of the first slide
var shapes = slides[0].Shapes;

// prints texts of shapes on the Debug console
foreach (var sp in shapes)
{
    if (sp.HasTextFrame)
    {
        Debug.WriteLine(sp.TextFrame.Text);
    }
}
```

## Changelog
### Version 0.7.0 - 2020-10-12
#### Added
- Added `Bullet` property for the paragraph:
    - Bullet.Type
    - Bullet.Char
    - Bullet.FontName
    - Bullet.Size
    - Bullet.ColorHex

To find out more, please check out the [CHANGELOG](https://github.com/adamshakhabov/SlideDotNet/blob/master/CHANGELOG.md).

## Contribution
If you have any problems or questions you can create an issue on this repository or contact me at <a href="mailto:theadamo86@gmail.com">theadamo86@gmail.com</a>.
If you want to contribute in improving this wrapper, feel free to [create pull requests](https://github.com/adamshakhabov/SlideDotNet/pulls).

## Author
**Adam Shakhabov** — [adamshakhabov](https://www.linkedin.com/in/adamshakhabov)
