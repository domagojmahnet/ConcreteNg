export interface CostOverview {
    taskName: string,
    totalmaterialCost: number,
    totalLabourCost: number,
    totalQuantity: number,
    unitOfMeasurement: string,
    partnerCosts: PartnerCost[],
    totalCost: number
} 

export interface PartnerCost {
    partnerName: string,
    totalCost: number
}