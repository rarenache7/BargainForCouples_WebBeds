import { Hotel } from "./hotel";
import { Rate } from "./rate";

export interface BargainOffer {
  hotel: Hotel;
  rates: Rate[];
}
