export class LoadTotalAssetsKpiAction {
  static readonly type = '[Dashboard] Load total assets kpi';
}

export class LoadTotalLiabilitiesKpiAction {
  static readonly type = '[Dashboard] Load total liabilities kpi';
}

export class LoadTotalNetWorthKpiAction {
  static readonly type = '[Dashboard] Load total net worth kpi';
}

export class LoadIncomesVsExpensesAction {
  static readonly type = '[Dashboard] Load incomes vs expenses';
}

export class LoadCashFlowAction {
  static readonly type = '[Dashboard] Load cash flow';
}

export class ReloadDashboardAction {
  static readonly type = '[Dashboard] Reload dashboard';
}

export class SetFromDateAction {
  static readonly type = '[Dashboard] Set From date';
  constructor(public readonly date: Date) {
  }
}
