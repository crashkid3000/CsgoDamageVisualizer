# CsgoDamageVisualizer
## ~~  Visualizer for CSGO weapon stats ~~

This piece of software aims to display the stats of the weapons in CSGO in a helpful manner in order to enhance everyones understanding about how they work.

### Project Structure

This project is split into four parts:

| Project                      | Purpose                                                             |
| ---------------------------- | ------------------------------------------------------------------- |
| CSgtoDamageVisualizer (sic!) | The desktop view of the software (WPF)                              |
| CsgoDamageVisualizerCore     | The actual utility: Cfg loading, models, calculations - you name it |
| CsgoDamageVisualizerTests    | Unit tests and other kinds of tests                                 |
| CsgoDamageVisuzalizerWeb     | The web view of the software (ASPX)                                 |

The primary focus lies in the development of the Core part. When that is finished, the main focus lies on the WPF view with the ASPX view following afterwards.

Please note that this is a project I do in my spare time, among other hobbies. :)