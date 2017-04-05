export class Cart {
    public cartId: number;
    public user: User;
    public totalPrice: number;
    public cartItems: Array<CartItem>;
    constructor() {
        this.cartItems = new Array<CartItem>();
    }
}

export class User {
    public userId: number;
    public userName: string;
}
export class CartItem {
    public cartItemId: number;
    public ad: any;
    public quantity: number;
    public rate: number;
    public discount: number;
}