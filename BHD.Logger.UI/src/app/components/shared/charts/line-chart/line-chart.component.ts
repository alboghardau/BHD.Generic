import { Component, Input, OnChanges, OnInit } from "@angular/core";
import { ChartData, ChartOptions } from "chart.js";
import { LineChartData } from "./line-chart-data.model";

@Component({
    selector: 'line-chart',
    templateUrl: './line-chart.component.html'
})
export class LineChartComponent implements OnChanges{

    public chartData: ChartData | undefined;
    public chartOptions: ChartOptions | undefined;

    @Input() data: LineChartData | undefined;
    @Input() datasetLabel: string = "";

    ngOnChanges(): void {

        const documentStyle = getComputedStyle(document.documentElement);
        const textColor = documentStyle.getPropertyValue('--text-color');
        const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
        const surfaceBorder = documentStyle.getPropertyValue('--surface-border');

        if(this.data)
            this.chartData = {
                labels: this.data?.labels,
                datasets: [
                    {                        
                        label: '',
                        data: this.data.values,
                        fill: true,
                        borderColor: documentStyle.getPropertyValue('--green-500'),
                        tension: 0.0
                    }
                ]
            };

        this.chartOptions = {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: false,
                    labels: {                        
                        color: textColor
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        color: textColorSecondary
                    },
                    grid: {
                        color: surfaceBorder
                    }
                },
                x: {
                    ticks: {
                        color: textColorSecondary
                    },
                    grid: {
                        color: surfaceBorder
                    }
                }
            }
        };

    }
}