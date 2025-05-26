import {Component, Input} from '@angular/core';
import {MatTreeFlatDataSource, MatTreeFlattener, MatTreeModule, MatTreeNode} from '@angular/material/tree';
import {FlatTreeControl} from '@angular/cdk/tree';
import {MatIconButton} from '@angular/material/button';
import {MatIcon} from '@angular/material/icon';

/**
 * Food data with nested structure.
 * Each node has a name and an optional list of children.
 */
interface CategoryNode {
  name: string;
  children?: CategoryNode[];
}

/** Flat node with expandable and level information */
interface ExampleFlatNode {
  expandable: boolean;
  name: string;
  level: number;
}

@Component({
  selector: 'app-categories-tree',
  imports: [
    MatTreeModule,
    MatIcon,
    MatIconButton
  ],
  templateUrl: './categories-tree.component.html',
  styleUrl: './categories-tree.component.css'
})
export class CategoriesTreeComponent {
  private _transformer = (node: CategoryNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level,
    };
  };

  treeControl = new FlatTreeControl<ExampleFlatNode>(
    node => node.level,
    node => node.expandable,
  );

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.children,
  );

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  @Input()
  set nodes(value: CategoryNode[]){
    this.dataSource.data = value;
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;
}

const EXAMPLE_DATA: CategoryNode[] = [
  {
    name: 'Fruit',
    children: [{name: 'Apple'}, {name: 'Banana'}, {name: 'Fruit loops'}],
  },
  {
    name: 'Vegetables',
    children: [
      {
        name: 'Green',
        children: [{name: 'Broccoli'}, {name: 'Brussels sprouts'}],
      },
      {
        name: 'Orange',
        children: [{name: 'Pumpkins'}, {name: 'Carrots'}],
      },
    ],
  },
];
