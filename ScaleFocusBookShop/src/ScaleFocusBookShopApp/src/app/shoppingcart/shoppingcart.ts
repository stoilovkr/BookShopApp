import { ShoppingCartDetail } from './shoppingcartdetail';

export class ShoppingCart{
    id: number;
    identityId: number;
    orderTimeStamp: Date;
    shoppingCartDetails: ShoppingCartDetail[];
    total: number;
}