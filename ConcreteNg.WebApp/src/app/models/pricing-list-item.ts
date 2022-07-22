export interface PricingListItem {
    pricingListItemId: number | null;
    pricingListItemName: string;
    unitOfMeasurement: string;
    price: number,
    employer?: any
}