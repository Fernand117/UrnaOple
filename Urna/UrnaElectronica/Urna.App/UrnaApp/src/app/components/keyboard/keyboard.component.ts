import { Component, ViewEncapsulation, Output, EventEmitter} from '@angular/core';
import Keyboard from "simple-keyboard";

@Component({
  selector: 'app-keyboard',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.scss']
})
export class KeyboardComponent  {
  value = "";
  keyboard: any = Keyboard ;
  @Output() miEvento = new EventEmitter<string>();
  
  ngAfterViewInit() {
    this.keyboard = new Keyboard({
      onChange: input => this.onChange(input),
      layout: {
        default: [
          "` 1 2 3 4 5 6 7 8 9 0 - = {bksp}",
          "{tab} q w e r t y u i o p [ ] \\",
          "{lock} a s d f g h j k l ; ' {enter}",
          "{shift} z x c v b n m , . / {shift}",
          ".com @ {space}"
        ],
        shift: [
          "~ ! @ # $ % ^ & * ( ) _ + {bksp}",
          "{tab} Q W E R T Y U I O P { } |",
          '{lock} A S D F G H J K L : " {enter}',
          "{shift} Z X C V B N M < > ? {shift}",
          ".com @ {space}"
        ],
        caps: [
          "` 1 2 3 4 5 6 7 8 9 0 - = {bksp}",
          "{tab} Q W E R T Y U I O P [ ] \\",
          "{lock} A S D F G H J K L ; ' {enter}",
          "{shift} Z X C V B N M , . / {shift}",
          ".com @ {space}"
        ]
      }
    });
  }

  onChange = (input: string) => {
    this.value = input;
  };

  onKeyPress = (button: string) => {
    console.log("Button pressed", button);

    if (button === "{shift}" || button === "{lock}") this.handleShift();
  };

  onInputChange = (event: any) => {
    this.keyboard.setInput(event.target.value);
  };

  handleShift = () => {
    let currentLayout = this.keyboard.options.layoutName;
    let shiftToggle = currentLayout === "default" ? "shift" : "default";

    this.keyboard.setOptions({
      layoutName: shiftToggle
    });
  };

  ejecutarEvento() {
    this.miEvento.emit(this.value);
  }

}
