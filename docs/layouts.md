# File layout

The file layout must be structured on XML format with this schema:
```xml
<?xml version="1.0"?>
<layout name="layoutname">
	<section ….. > </section>
	<section ….. > </section>
	<section ….. > </section>
	<section ….. > </section>
</layout>
```

The __layoutname__ specifies the name of layout to call by API method "SetLayout"

For rendering on display of LEDbox you must use the "section" tags. Every tag "section" has general attributes, these are showing below:


| attribute | value                                | default     | description                                                                                                                                                   | required |
|-----------|--------------------------------------|-------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|----------|
| type      | enum(text, image, rectangle, circle) | Text        | type of section                                                                                                                                               | Yes      |
| name      | String                               |             | section name                 										                                                                                         | Yes      |
| x         | Int                                  | 0           | horizontal position in pixel                                                                                                                                  | Yes      |
| y         | int                                  | 0           | vertical position in pixel                                                                                                                                    | Yes      |
| visible   | Boolean [true,false]                 | True        | show or hide the section                                                                                                                                      | No       |
| private   | Boolean [true,false]                 | False       | exclude the section when use API method "GetSection" or "GetSections"                                                                                         | No       |
| enable    | Boolean [true,false]                 | True        | enable or disable extra functionality (as example counter or animation )                                                                                      | No       |

# Text

Render a text
```xml
<section type="text" name="team1" x="0" y="-3" fontsize="18" color="0,0,255" align="left">TEAM A</section>
```


| attribute | value                                | default     | description                                                                                                                                                   | required |
|-----------|--------------------------------------|-------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|----------|
| fontsize  | int                                  | 0           | font size of text                                                                                                                                             | Yes      |
| color     | [int,int,int                         | 0,0,        | RGB color of text              										                                                                                         | Yes      |
| align     | enum(left,right,center)              | left        | horizontal text alignment                                                                                                                                     | Yes      |
| animation | enum(none,scroller_x, scroller_y, blinking, blinkingborder)|           | Animation effect | Yes      |
| animation_params | String [Json]   |         | Parameters for blinking animation. The JSON will contains: <br /><ul><li>color1: color primary;</li><li>color2: color secondary;</li><li>count: number of times of blinking; if "0" is infinity loop</li><li>pause: valore in millisecondi indicante la pausa tra un blink ed un altro</li></ul><br />Example:<br />{“color1”:”255, 0,0”,”color2”:”0,255,0”,”pause”:”1000”,”count”:”10} | No       |

# Image

Render a image in JPG, PNG o GIF (also animate) format.

```xml
<section type="image" src="user1/banner1.jgp" name="media" x="96" y="0" width="192" height="64" align="center" valign=”center”></section>
```

| attribute | value                   | default | description                                                  | required |
| --------- | ----------------------- | ------- | ------------------------------------------------------------ | -------- |
| src       | String                  |         | Relative path (folder media of LEDbox) of image. If it's animate GIF this will be play in loop mode. | Yes      |
| align     | Enum[left,right,center] | left    | horizonalt alignment of image respect  x attribute           | No       |
| valign    | Enum[top,bottom,center] | top     | vertical alignment of image respect  y attribute             | No       |

# Rectangle

Render a rectangle

```xml
<section type="rectangle" private="true" name="bg_score1" x="0" y="17" width="64" height="46" bordercolor="0,0,255"></section>
```

| attribute        | value                           | default | description                                                  | required |
| ---------------- | ------------------------------- | ------- | ------------------------------------------------------------ | -------- |
| width            | int                             | 0       | width (pixel) of rectangle                                   | Yes      |
| height           | int                             | 0       | height (pixel) of rectangle                                  | Yes      |
| bordercolor      | [int,int,int]                   | 0,0,0   | RGB color of the border of rectangle                         | No       |
| color            | [int,int,int]                   | 0,0,0   | RGB color of the background of rectangle                     | No       |
| animation        | Enum [blinking, blinkingborder] |         | Animation effect                                             | No       |
| animation_params | String [Json]                   |         | Parameters for blinking animation. The JSON will contains: <br /><ul><li>color1: color primary;</li><li>color2: color secondary;</li><li>count: number of times of blinking; if "0" is infinity loop</li><li>pause: valore in millisecondi indicante la pausa tra un blink ed un altro</li></ul><br />Example:<br />{“color1”:”255, 0,0”,”color2”:”0,255,0”,”pause”:”1000”,”count”:”10} | No       |

# Circle

Render a circle or ellipse

```xml
<section type="circle" private="true" name="bg_score1" x="0" y="17" width="64" height="46" bordercolor="0,0,255"></section>
```

| attribute        | value                           | default | description                                                  | required |
| ---------------- | ------------------------------- | ------- | ------------------------------------------------------------ | -------- |
| width            | int                             | 0       | width (pixel) of circle                                      | Si       |
| height           | int                             | 0       | height (pixel) of circle                                     | Si       |
| bordercolor      | [int,int,int]                   | 0,0,0   | RGB color of the border of circle                            | No       |
| color            | [int,int,int]                   | 0,0,0   | RGB color of the background of circle                        | No       |
| animation        | Enum [blinking, blinkingborder] |         | Animation effect                                             | No       |
| animation_params | String [Json]                   |         | Parameters for blinking animation. The JSON will contains: <br /><ul><li>color1: color primary;</li><li>color2: color secondary;</li><li>count: number of times of blinking; if "0" is infinity loop</li><li>pause: valore in millisecondi indicante la pausa tra un blink ed un altro</li></ul><br />Example:<br />{“color1”:”255, 0,0”,”color2”:”0,255,0”,”pause”:”1000”,”count”:”10} | No       |

# Counter

Render a timer.

```xml
<section type="counter" name="timer" x="0" y="-3" fontsize="18" color="0,0,255" align="left" parameter=” {'type':'countdown','start':100,'stop':5,'format':'%M:%S'}”> </section>
```


| attribute        | value                                                  | default | description                                                  | required |
| ---------------- | ------------------------------------------------------ | ------- | ------------------------------------------------------------ | -------- |
| fontsize         | int                                                    | 0       | Font size of counter                                         | Yes      |
| color            | [int,int,int]                                          | 0,0,0   | RGB color of text                                            | Yes      |
| align            | Enum[left,right,center]                                | left    | Horizontal text alignment                                    | Yes      |
| animation        | Enum[scroller_x, scroller_y, blinking, blinkingborder] |         | Animation effect                                             | No       |
| animation_params | String [Json]                                          |         | Parameters for blinking animation. The JSON will contains: <br /><ul><li>color1: color primary;</li><li>color2: color secondary;</li><li>count: number of times of blinking; if "0" is infinity loop</li><li>pause: valore in millisecondi indicante la pausa tra un blink ed un altro</li></ul><br />Example:<br />{“color1”:”255, 0,0”,”color2”:”0,255,0”,”pause”:”1000”,”count”:”10} | No       |
| parameters       | String [Json]                                          |         | Parameters of counter. The JSON will contain:<br /><ul><li>start: start time in seconds</li><li>stop: stop time in seconds</li><li>type:  “countup” or “countdown”</li><li>format: text format of timer (example “%H:%M%S” for 00:00:00, or “%TM” for #00:00)</li></ul><br />Example:<br />{'type':'countdown','start':100,'stop':5,'format':'%M:%S'} | Yes      |


