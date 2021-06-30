import { EBoardType } from "./enums/EBoardType.enum";
import { ERateType } from "./enums/ERateType.enum";

export interface Rate {
  rateType: ERateType;
  boardType: EBoardType;
  value: number;
}
